using BaitM8s.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.APIClient.Interfaces
{
    public interface IAnglerAPIClient
    {
        Task<IEnumerable<AnglerDTO>> GetAllAsync();
        Task<AnglerDTO?> GetOneAsync(int id);
    }
}
