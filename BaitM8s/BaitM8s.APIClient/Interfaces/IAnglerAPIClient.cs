using BaitM8s.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.APIClient.Interfaces
{
    public interface IAnglerAPIClient
    {
        IEnumerable<Angler> GetAllAsync();
        Angler? GetOneAsync(int id);
        bool DeleteAsync(int id);
        int CreateAsync(Angler angler);
    }
}
