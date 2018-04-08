using BuildIndia.Data;
using BuildIndia.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildIndia.Service.Repository
{
    public class CompactorRepository
    {
        public void Save(CompactorViewModel compactorViewModel)
        {
            using (var _context = new NasscomEntities())
            {
                Compactor compactor = _context.Compactor.Find(compactorViewModel.Id);
                if (compactor != null)
                {
                    compactor.CompactorNumber = compactorViewModel.CompactorNumber;
                    compactor.LocationId = compactorViewModel.LocationId;
                    compactor.Make = compactorViewModel.Make;
                    compactor.Size = compactorViewModel.Size;
                }
                else
                {
                    _context.Compactor.Add(GetEntity(compactorViewModel));
                }
                _context.SaveChanges();
            }
        }
        public CompactorViewModel GetCompactorById(int id)
        {
            CompactorViewModel compactor = null;
            using (var _context = new NasscomEntities())
            {
                compactor = (from allCompactors in _context.Compactor
                             where allCompactors.Id == id
                             select new CompactorViewModel()
                             {
                                 CompactorNumber = allCompactors.CompactorNumber,
                                 Id = allCompactors.Id,
                                 LocationId = allCompactors.LocationId,
                                 Make = allCompactors.Make,
                                 Size = allCompactors.Size

                             }).FirstOrDefault();
            }
            if (compactor != null)
            {
                return compactor;
            }
            else
                return new CompactorViewModel();
        }


        public List<CompactorViewModel> GetAllCompactors()
        {
            List<CompactorViewModel> compactors = null;
            using (var _context = new NasscomEntities())
            {
                compactors = (
                    from pd in _context.Compactor
                    join od in _context.Location on pd.LocationId equals od.Id

                    select new CompactorViewModel()
                    {
                        CompactorNumber = pd.CompactorNumber,
                        Id = pd.Id,
                        LocationId = pd.LocationId,
                        Location = od.Name,
                        Make = pd.Make,
                        Size = pd.Size
                    }
                    ).ToList();
            }
            if (compactors != null)
            {
                return compactors;

            }
            else
                return new List<CompactorViewModel>();
        }

        private Compactor GetEntity(CompactorViewModel compactorViewModel)
        {
            Compactor compactor = new Compactor()
            {
                CompactorNumber = compactorViewModel.CompactorNumber,
                Id = compactorViewModel.Id,
                LocationId = compactorViewModel.LocationId,
                Make = compactorViewModel.Make,
                Size = compactorViewModel.Size
            };

            return compactor;
        }
        private CompactorViewModel GetModel(Compactor compactorViewModel)
        {
            CompactorViewModel compactor = new CompactorViewModel()
            {
                CompactorNumber = compactorViewModel.CompactorNumber,
                Id = compactorViewModel.Id,
                LocationId = compactorViewModel.LocationId,
                Make = compactorViewModel.Make,
                Size = compactorViewModel.Size
            };

            return compactor;
        }

    }
}
