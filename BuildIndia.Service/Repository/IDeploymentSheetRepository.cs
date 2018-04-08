using BuildIndia.Data;
using BuildIndia.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildIndia.Service.Repository
{
   public interface IDeploymentSheetRepository
    {
        DeploymentSheetMainViewModel InitDeploymentSheet(DateTime deploymentDate);
        void Save(List<DeploymentSheetModel> model);
    }
}
