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

    public class CompactorController : ApiController
    {
        private CompactorRepository _compRepo;
        private LocationRepository _locRepo;
        public CompactorController()
        {
            _compRepo = new CompactorRepository();
            _locRepo = new LocationRepository();
        }
        private class AllResult {
            public List<CompactorViewModel> Compactors;
            public List<LocationViewModel> Locations;
        }

        public IHttpActionResult Get()
        {
            AllResult result = new AllResult
            { Compactors = _compRepo.GetAllCompactors(),
                Locations = _locRepo.GetAllLocations()
               

            };
            return Ok(result);
        }
        [HttpPost]
        public IHttpActionResult PostAddCompactor(CompactorViewModel compactor)
        {
            _compRepo.Save(compactor);
            return Ok();
        }
    }
}
