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
    public class ComplainRepository : IComplainRepository
    {
        public List<ComplainViewModel> GetAllComplains()
        {
            List<ComplainViewModel> complains = null;
            using (var _context = new NasscomEntities())
            {
                complains = (from complain in _context.Complains
                             select
                            new ComplainViewModel
                            {
                                ComplainID = complain.ComplainID,
                                Name = complain.Name,
                                Email = complain.Email,
                                ContactNumber = complain.ContactNumber,
                                Location = complain.Location,
                                Compactor = complain.Compactor,
                                Decription = complain.Description

                            }).ToList();
            }
            if (complains != null)
            {
                return complains;
            }
            else
                return new List<ComplainViewModel>();

        }
        public ComplainViewModel GetComplains(string contactNumber)
        {
            ComplainViewModel complain = null;
            using (var _context = new NasscomEntities())
            {
                complain = (from complains in _context.Complains
                            where complains.ContactNumber == contactNumber
                            select
                              new ComplainViewModel
                              {
                                  Name = complains.Name,
                                  Email = complains.Email,
                                  ContactNumber = complains.ContactNumber,
                                  Location = complains.Location,
                                  Decription = complains.Description,
                                  Compactor = complains.Compactor

                              }).FirstOrDefault();
            }
            if (complain != null)
            {
                return complain;
            }
            else
                return new ComplainViewModel();


        }
        public void Save(ComplainViewModel complain)
        {
            Complains compalinsmodel = GetEntity(complain);
            using (var _context = new NasscomEntities())
            {
                var tt = _context.Complains.ToList();
                Complains complaincheck = _context.Complains.Find(compalinsmodel.ComplainID);

                if (complaincheck != null)
                {
                    complaincheck.Name = compalinsmodel.Name;
                    complaincheck.Email = compalinsmodel.Email;
                    complaincheck.ContactNumber = compalinsmodel.ContactNumber;
                    complaincheck.Location = compalinsmodel.Location;
                    complaincheck.Compactor = compalinsmodel.Compactor;
                    complaincheck.Description = compalinsmodel.Description;

                }
                else
                {
                    _context.Complains.Add(compalinsmodel);
                }
                _context.SaveChanges();
            }

        }
        private Complains GetEntity(ComplainViewModel complain)
        {
            Complains complainsEntity = new Complains();
            if (complain != null)
            {
                complainsEntity.Name = complain.Name;
                complainsEntity.Email = complain.Email;
                complainsEntity.ContactNumber = complain.ContactNumber;
                complainsEntity.Location = complain.Location;
                complainsEntity.Compactor = complain.Compactor;
                complainsEntity.Description = complain.Decription;
            }
            return complainsEntity;
        }
        private ComplainViewModel GetModel(Complains complain)
        {
            ComplainViewModel complainModel = new ComplainViewModel()
            {
                Name = complain.Name,
                Email = complain.Email,
                ContactNumber = complain.ContactNumber,
                Location = complain.Location,
                Compactor = complain.Compactor,
                Decription = complain.Description,

            };
            return complainModel;

        }
    }
}