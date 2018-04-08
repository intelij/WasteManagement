using BuildIndia.Data;
using BuildIndia.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildIndia.Service.Repository
{
    public class LocationRepository
    {
        public void Save(LocationViewModel locationViewModel)
        {
            using (var _context = new NasscomEntities())
            {
                Location location = (from locations in _context.Location where locations.Id == locationViewModel.Id select locations).FirstOrDefault();
                if (location != null)
                {
                    location.Id = locationViewModel.Id;
                    location.Description = locationViewModel.Description;
                    location.Name = locationViewModel.Name;
                }
                else
                {
                    _context.Location.Add(GetEntity(locationViewModel));
                }

                _context.SaveChanges();
            }
        }
        public List<LocationViewModel> GetAllLocations()
        {
            List<LocationViewModel> locations = null;
            using (var _context = new NasscomEntities())
            {
                locations = (from alllocations in _context.Location select new LocationViewModel()
                {
                    Description = alllocations.Description,
                    Id = alllocations.Id,
                    Name = alllocations.Name

                }).ToList();
            }
            if (locations != null)
            {
                return locations;
            }
            else
                return locations;
        }

        public LocationViewModel GetLocationById(int id)
        {
            LocationViewModel location = null;
            using (var _context = new NasscomEntities())
            {
                location = (from alllocations in _context.Location
                            where alllocations.Id == id
                            select new LocationViewModel()
                            {
                                Description = alllocations.Description,
                                Id = alllocations.Id,
                                Name = alllocations.Name

                            }).FirstOrDefault();
            }
            if (location != null)
            {
                return location;

            }
            else
                return new LocationViewModel();

        }

        private Location GetEntity(LocationViewModel locationViewModel)
        {
            Location location = new Location()
            {

                Description = locationViewModel.Description,
                Id = locationViewModel.Id,
                Name = locationViewModel.Name

            };
            return location;
        }
        private LocationViewModel GetModel(Location location)
        {
            LocationViewModel locationViewModel = new LocationViewModel()
            {

                Description = location.Description,
                Id = location.Id,
                Name = location.Name

            };
            return locationViewModel;
        }
    }
}
