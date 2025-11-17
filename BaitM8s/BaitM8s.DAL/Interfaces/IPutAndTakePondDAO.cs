using BaitM8s.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.Interfaces
{
    public interface IPutAndTakePondDAO
    {
        PutAndTakePond? GetOne(int id);
        IEnumerable<PutAndTakePond> GetAll();
        IEnumerable<PutAndTakePond> GetByPondOwner(int pondOwnerId);
        bool Delete(int id);
        bool Update(PutAndTakePond putAndTakePond);
        int Create(PutAndTakePond putAndTakePond);
    }
}
