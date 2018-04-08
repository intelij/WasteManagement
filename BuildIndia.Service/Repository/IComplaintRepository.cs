using System.Collections.Generic;
namespace BuildIndia.Service.Repository
{

    interface IComplainRepository
    {
        void Save(ComplainViewModel complain);
        List<ComplainViewModel> GetAllComplains();
        ComplainViewModel GetComplains(string contactNumber);
    }
}