using BuildIndia.Service.Repository;
using BuildIndia.ViewModel;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DummyWebApi.Controller
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        private HomeRepository _homeRepo;

        public HomeController()
        {
            _homeRepo = new HomeRepository();
        }
        public IHttpActionResult Get()
        {
            return Ok(_homeRepo.GetDashboardData());

        }
    }
}