using BuildIndia.Data;
using BuildIndia.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildIndia.Service.Repository
{
    public class RouteRepository
    {

        public void Save(RouteViewModel routeViewModel)
        {
            using (var _context = new NasscomEntities())
            {
                Route route = (from routes in _context.Route where routes.Id == routeViewModel.Id select routes).FirstOrDefault();
                if (route != null)
                {
                    route.Id = routeViewModel.Id;
                    route.CrewID = routeViewModel.CrewID;
                    route.DriverID = routeViewModel.DriverID;
                    route.WorkerID = routeViewModel.WorkerID;
                    route.locations = string.Join("; ", routeViewModel.locations);
                    route.RouteNumber = routeViewModel.RouteNumber;
                    route.VehicleNo = routeViewModel.VehicleNo;

                }
                else
                {
                    _context.Route.Add(GetEntity(routeViewModel));
                }
                _context.SaveChanges();
            }
        }

        public List<RouteViewModel> GetAllRoutes()
        {
            List<RouteViewModel> routes = null;
            using (var _context = new NasscomEntities())
            {
                routes = (from allroutes in _context.Route
                          join d in _context.Staff on allroutes.DriverID equals d.Id
                          join c in _context.Staff on allroutes.CrewID equals c.Id
                          join w in _context.Staff on allroutes.WorkerID equals w.Id
                          join v in _context.Vehicle on allroutes.VehicleNo equals v.VehicleNo
                          select new RouteViewModel()
                          {
                              CrewID = allroutes.CrewID,
                              DriverID = allroutes.DriverID,
                              WorkerID = allroutes.WorkerID,
                              Id = allroutes.Id,
                              Location = allroutes.locations,
                              Driver = d.Name,
                              Crew = c.Name,
                              Worker = w.Name,
                              Vehicle = v.Make,
                              RouteNumber = allroutes.RouteNumber,
                              VehicleNo = allroutes.VehicleNo
                          }).ToList();
            }
            if (routes != null && routes.Any())
            {
                return routes;
            }
            else
                return new List<RouteViewModel>();
        }

        public RouteViewModel GetRouteById(int id)
        {
            RouteViewModel route = null;

            using (var _context = new NasscomEntities())
            {
                route = (from allroutes in _context.Route
                         where allroutes.Id == id
                         select
                        new RouteViewModel()
                        {
                            CrewID = allroutes.CrewID,
                            DriverID = allroutes.DriverID,
                            WorkerID = allroutes.WorkerID,
                            Id = allroutes.Id,
                            RouteNumber = allroutes.RouteNumber,
                            VehicleNo = allroutes.VehicleNo
                        }

                         ).FirstOrDefault();
            }
            if (route != null)
            {
                return route;
            }
            else
                return new RouteViewModel();

        }
        public RouteViewModel GetRouteByRouteNum(string routeNum)
        {
            RouteViewModel route = null;

            using (var _context = new NasscomEntities())
            {
                route = (from allroutes in _context.Route
                         where allroutes.RouteNumber == routeNum
                         select
                         new RouteViewModel()
                         {
                             CrewID = allroutes.CrewID,
                             DriverID = allroutes.DriverID,
                             WorkerID = allroutes.WorkerID,
                             Id = allroutes.Id,
                             RouteNumber = allroutes.RouteNumber,
                             VehicleNo = allroutes.VehicleNo
                         }).FirstOrDefault();
            }
            if (route != null)
            {
                return route;
            }
            else
                return new RouteViewModel();

        }


        private Route GetEntity(RouteViewModel routeViewModel)
        {
            Route route = new Route()
            {
                CrewID = routeViewModel.CrewID,
                DriverID = routeViewModel.DriverID,
                WorkerID = routeViewModel.WorkerID,
                Id = routeViewModel.Id,
                locations = string.Join("; ",routeViewModel.locations),
                RouteNumber = routeViewModel.RouteNumber,
                VehicleNo = routeViewModel.VehicleNo
            };
            return route;
        }
    }
}
