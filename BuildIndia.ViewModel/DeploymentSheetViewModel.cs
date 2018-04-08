using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildIndia.ViewModel
{
    public class DeploymentSheetMainViewModel
    {
        public List<DropDownViewModel> AvailableDriver { get; set; }
        public List<DropDownViewModel> AvailableCrew { get; set; }
        public List<DropDownViewModel> AvailableWorker { get; set; }
        public List<DeploymentSheetViewModel> DeploymentSheet { get; set; }
    }
    public class DeploymentSheetViewModel
    {
        public string RouteNo { get; set; }
        public string VehicleNo { get; set; }
        public List<DeploymentSheetModel> Deployments { get; set; }
        public List<DropDownViewModel> Drivers { get; set; }
        public List<DropDownViewModel> CrewMembers { get; set; }
        public List<DropDownViewModel> Workers { get; set; }

    }

    public class DeploymentSheetModel
    {
        public int Id { get; set; }
        public string RouteNumber { get; set; }
        public Nullable<System.DateTime> DeploymentDate { get; set; }
        public string VehicleNo { get; set; }
        public Nullable<int> Substitute { get; set; }
        public Nullable<int> StaffId { get; set; }
        public Nullable<int> StaffType { get; set; }
        public string StaffName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Designation { get; set; }
    }

    public class DropDownViewModel
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }

}
