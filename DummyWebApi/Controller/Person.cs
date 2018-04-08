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

    public class PersonController : ApiController
    {
        private StaffRepoistory _staffRepo;
       public PersonController()
        {
            _staffRepo = new StaffRepoistory();
        }
        public IHttpActionResult Get()
        {
            return Ok(_staffRepo.GetAllStaffMembers());
        }

        public IHttpActionResult Post(StaffViewModel staffmember)
        {
            _staffRepo.Save(staffmember);
            return Ok();
            
        }
        public IHttpActionResult Put(StaffViewModel staffmember)
        {
            _staffRepo.Save(staffmember);
            return Ok();
        }
    }
}
