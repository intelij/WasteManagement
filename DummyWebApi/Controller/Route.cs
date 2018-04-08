using BuildIndia.Service.Repository;
using BuildIndia.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DummyWebApi.Controller
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class RouteController : ApiController
    {
        private RouteRepository _routeRepo;
        private VehicleRepository _routeVehicle;
        private StaffRepoistory _routeStaff;
        private LocationRepository _routeLocation;
        allResult liObj;
        private class allResult
        {
            public List<RouteViewModel> Routes { get; set; }
            public List<VehicleViewModel> Vehicles { get; set; }
            public List<StaffViewModel> Staffs { get; set; }
            public List<LocationViewModel> Locations { get; set; }
        }
        public RouteController()
        {
            liObj = new allResult();
            _routeRepo = new RouteRepository();
            _routeVehicle = new VehicleRepository();
            _routeStaff = new StaffRepoistory();
            _routeLocation = new LocationRepository();
        }
        public IHttpActionResult Get()
        {
            liObj.Routes = _routeRepo.GetAllRoutes();
            liObj.Vehicles = _routeVehicle.GetAllVehicles();
            liObj.Staffs = _routeStaff.GetAllStaffMembers();
            liObj.Locations = _routeLocation.GetAllLocations();
            return Ok(liObj);
        }
        [HttpPost]
        public IHttpActionResult PostAddRoute(RouteViewModel route)
        {
            _routeRepo.Save(route);
            return Ok();
        }
    }
}
