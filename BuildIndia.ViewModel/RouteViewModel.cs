using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildIndia.ViewModel
{
    public class RouteViewModel
    {
        public int Id { get; set; }
        public string RouteNumber { get; set; }
        public string VehicleNo { get; set; }
        public int? DriverID { get; set; }
        public int? CrewID { get; set; }
        public int? WorkerID { get; set; }
        public string[] locations { get; set; }
        public string Location { get; set; }
        public string Driver { get; set; }
        public string Crew { get; set; }
        public string Worker { get; set; }
        public string Vehicle { get; set; }
    }
}
