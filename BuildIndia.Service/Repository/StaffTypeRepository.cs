using BuildIndia.Data;
using BuildIndia.ViewModel;
using System.Collections.Generic;
using System.Linq;
    
namespace BuildIndia.Service.Repository
{
    public class StaffTypeRepository
    {
        public void Save(StaffTypeViewModel staffTypeViewModel)
        {
            using (var _context = new NasscomEntities())
            {
                _context.StaffType.Add(GetEntity(staffTypeViewModel));
                _context.SaveChanges();
            }

        }
        public List<StaffTypeViewModel> GetAllStaffTypes()
        {
            List < StaffTypeViewModel > staffTypes = null;
            using (var _context = new NasscomEntities())
            {
                staffTypes = (from allstaffTypes in _context.StaffType select new StaffTypeViewModel()
                {
                    Id = allstaffTypes.Id,
                    TypeDescription = allstaffTypes.TypeDescription
                }).ToList();
            }
            if (staffTypes != null)
            {
                return staffTypes;
            }
            else
                return new List<StaffTypeViewModel>();
        }

        public StaffTypeViewModel GetStaffTypeById(int id)
        {
            StaffTypeViewModel staffType = null;
            using (var _context = new NasscomEntities())
            {
                staffType = (from allstafftypes in _context.StaffType where allstafftypes.Id == id select new StaffTypeViewModel() {
                    Id = allstafftypes.Id,
                    TypeDescription = allstafftypes.TypeDescription
                }).FirstOrDefault();
            }

            return staffType;

        }

        private StaffType GetEntity(StaffTypeViewModel staffViewModel)
        {
            StaffType staffType = new StaffType()
            {
                Id = staffViewModel.Id,
                TypeDescription = staffViewModel.TypeDescription
            };
            return staffType;
        }
        private StaffTypeViewModel GetModel(StaffType stafftype)
        {
            StaffTypeViewModel staffViewModel = new StaffTypeViewModel()
            {
                Id = stafftype.Id,
                TypeDescription = stafftype.TypeDescription
            };
            return staffViewModel;
        }
    }
}
