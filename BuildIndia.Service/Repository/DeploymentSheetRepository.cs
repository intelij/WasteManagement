using BuildIndia.Data;
using BuildIndia.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static BuildIndia.ViewModel.Constants;

namespace BuildIndia.Service.Repository
{
    public class DeploymentSheetRepository : IDeploymentSheetRepository
    {
        public DeploymentSheetMainViewModel InitDeploymentSheet(DateTime deploymentDate)
        {
            var deploymentRouteSheet = new List<DeploymentSheetViewModel>();
            var result = new DeploymentSheetMainViewModel();

            var allocatedDrivers = new List<int>();
            var allocatedCrews = new List<int>();
            var allocatedWorkers = new List<int>();

            using (var _context = new NasscomEntities())
            {
                var routes = _context.Route;
                var routeDeployments = _context.usp_FetchDeploymentSheetByDate(deploymentDate.Date).ToList();
                foreach (var route in routes)
                {
                    var item = new DeploymentSheetViewModel();
                    item.RouteNo = route.RouteNumber;
                    item.VehicleNo = route.VehicleNo;
                    item.Drivers = _context.usp_FetchStaffByRouteNo(route.RouteNumber, (int)StaffTypeEnm.Driver).Select(q => new DropDownViewModel
                    {
                        Value = q.Value,
                        Text = q.Text
                    }).ToList();
                    allocatedDrivers.AddRange(item.Drivers.Select(q => q.Value));

                    item.CrewMembers = _context.usp_FetchStaffByRouteNo(route.RouteNumber, (int)StaffTypeEnm.Crew).Select(q => new DropDownViewModel
                    {
                        Value = q.Value,
                        Text = q.Text
                    }).ToList();
                    allocatedCrews.AddRange(item.CrewMembers.Select(q => q.Value));

                    item.Workers = _context.usp_FetchStaffByRouteNo(route.RouteNumber, (int)StaffTypeEnm.Worker).Select(q => new DropDownViewModel
                    {
                        Value = q.Value,
                        Text = q.Text
                    }).ToList();
                    allocatedCrews.AddRange(item.Workers.Select(q => q.Value));

                    item.Deployments = routeDeployments.Where(q => q.RouteNumber == route.RouteNumber).Select(q => new DeploymentSheetModel
                    {
                        Id = q.Id ?? 0,
                        RouteNumber = q.RouteNumber,
                        VehicleNo = q.VehicleNo,
                        Substitute = q.Substitute,
                        StaffId = q.Id,
                        StaffType = q.StaffType,
                        StaffName = q.StaffName,
                        Email = q.Email,
                        Phone = q.Phone,
                        Designation = q.Designation

                    }).OrderBy(q => q.StaffType).ToList();

                    deploymentRouteSheet.Add(item);
                }

                var availableDrivers = _context.Staff.Where(q => q.StaffType == (int)StaffTypeEnm.Driver &&
                                                            !allocatedDrivers.Contains(q.Id));

                var availableCrews = _context.Staff.Where(q => q.StaffType == (int)StaffTypeEnm.Crew &&
                                                            !allocatedCrews.Contains(q.Id));

                var availableWorker = _context.Staff.Where(q => q.StaffType == (int)StaffTypeEnm.Worker &&
                                                            !allocatedWorkers.Contains(q.Id));

                result.AvailableDriver = availableDrivers.Select(q => new DropDownViewModel { Text = q.Name, Value = q.Id }).ToList();
                result.AvailableCrew = availableCrews.Select(q => new DropDownViewModel { Text = q.Name, Value = q.Id }).ToList();
                result.AvailableWorker = availableWorker.Select(q => new DropDownViewModel { Text = q.Name, Value = q.Id }).ToList();
                result.DeploymentSheet = deploymentRouteSheet;
            }
            
            return result;
        }

        public void Save(List<DeploymentSheetModel> model)
        {
            using (var _context = new NasscomEntities())
            {

                if (model.Count > 0)
                {
                    var entityTobeDelete = _context.DeploymentSheet.Where(q => q.DeploymentDate == model.First().DeploymentDate).AsQueryable();
                    foreach (var item in entityTobeDelete)
                    {
                        _context.DeploymentSheet.Remove(item);
                    }
                }


                foreach (var item in model)
                {



                    //if (item.Id > 0)
                    //{
                    //    var updatedEntity = _context.DeploymentSheet.Find(item.Id);

                    //    updatedEntity.Id = item.Id;
                    //    updatedEntity.RouteNumber = item.RouteNumber;
                    //    updatedEntity.DeploymentDate = item.DeploymentDate;
                    //    updatedEntity.VehicleNo = item.VehicleNo;
                    //    updatedEntity.Substitute = item.Substitute;
                    //    updatedEntity.StaffId = item.StaffId;
                    //    updatedEntity.StaffType = item.StaffType;

                    //    _context.Entry(updatedEntity).State = EntityState.Modified;

                    //}
                    //else
                    //{
                    var entity = GetEntity(item);
                    _context.DeploymentSheet.Add(entity);
                    //}
                    _context.SaveChanges();
                }
            }
        }

        private DeploymentSheet GetEntity(DeploymentSheetModel model)
        {
            DeploymentSheet result = new DeploymentSheet
            {
                Id = model.Id,
                RouteNumber = model.RouteNumber,
                DeploymentDate = model.DeploymentDate,
                VehicleNo = model.VehicleNo,
                Substitute = model.Substitute,
                StaffId = model.StaffId,
                StaffType = model.StaffType
            };
            return result;
        }
    }
}
