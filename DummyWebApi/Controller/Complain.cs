using BuildIndia.Service.Repository;
using BuildIndia.ViewModel;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;


namespace DummyWebApi.Controller
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class ComplainController : ApiController
    {
        private ComplainRepository _compRepo;
        private LocationRepository _locReop;
        private CompactorRepository _comprepo;
        private class AllResult
        {
            public List<ComplainViewModel> complaints;
            public List<LocationViewModel> locations;
            public List<CompactorViewModel> compactors;
        }
        
       public ComplainController()
        {
            _compRepo = new ComplainRepository();
            _locReop = new LocationRepository();
            _comprepo = new CompactorRepository();
        }
        public IHttpActionResult Get()
        {
            AllResult result = new AllResult
            {
                complaints = _compRepo.GetAllComplains(),
                locations = _locReop.GetAllLocations(),
                compactors = _comprepo.GetAllCompactors()
            };
            return Ok(result);

        }
        [HttpPost]
        public IHttpActionResult PostAddVehicle(ComplainViewModel complain)
        {

            _compRepo.Save(complain);
            return Ok();
        }
    }
}
