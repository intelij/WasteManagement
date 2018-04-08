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

    public class DeploymentSheetController : ApiController
    {
        private readonly IDeploymentSheetRepository _service;

        public DeploymentSheetController()
        {
            _service = new DeploymentSheetRepository();
        }

        public IHttpActionResult Get(string deploymentDate)
        {
            return Ok(_service.InitDeploymentSheet(DateTime.Now));
            //return Ok(_service.InitDeploymentSheet(Convert.ToDateTime(deploymentDate)));

        }
    }
}
