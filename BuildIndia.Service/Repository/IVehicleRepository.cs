using BuildIndia.Data;
using BuildIndia.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildIndia.Service.Repository
{
    interface IVehicleRepository
    {
         void Save(VehicleViewModel vehicle);
         List<VehicleViewModel> GetAllVehicles();
         VehicleViewModel GetVehicle(string vehicleNo);
    }
}
