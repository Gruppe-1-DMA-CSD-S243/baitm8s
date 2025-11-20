using BaitM8s.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.Interfaces
{
    public interface IPutAndTakePondDao
    {
        Task<IEnumerable<PutAndTakePond>> GetAllPutAndTakePondsAsync();
        Task<PutAndTakePond> GetPutAndTakePondByIdAsync(int pondNumber);
        Task<int> CreatePutAndTakePondAsync(PutAndTakePond pond);
        Task UpdatePutAndTakePondAsync(PutAndTakePond pond);
        Task DeletePutAndTakePondAsync(int pondNumber);
    }
}
