using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildIndia.Data;
using BuildIndia.ViewModel;
using System.Data.Entity;
using System.Data.Objects.SqlClient;

namespace BuildIndia.Service.Repository
{
    public class HomeRepository
    {
        public HomeViewModel GetDashboardData()
        {
            HomeViewModel Dashboard = new HomeViewModel();

            using (var _context = new NasscomEntities())
            {
                var a = (from o in _context.Compactor select o).ToList();
                Dashboard.Compactors = a != null ? a.Count : 0;
                Dashboard.Vehicles = (from o in _context.Vehicle
                                      select o).Count();
                Dashboard.Routes = (from o in _context.Route
                                    select o).Count();
                Dashboard.Persons = (from o in _context.Staff
                                     select o).Count();
                Dashboard.Deployments = (from o in _context.DeploymentSheet
                                         select o).Count();
                Dashboard.Complaints = (from o in _context.Complains
                                        select o).Count();
                Dashboard.Locations = (from o in _context.Location
                                       select o).Count();
            }
            return Dashboard;

        }
    }
}
