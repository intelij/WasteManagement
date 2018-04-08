using BuildIndia.Service.Repository;
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
   public class LocationController : ApiController
    {
        private LocationRepository _locationrepo;
        public LocationController()
        {
            _locationrepo = new LocationRepository();
        }

        public IHttpActionResult GetAllLocations()
        {
           return Ok( _locationrepo.GetAllLocations());
        }
    }
}
