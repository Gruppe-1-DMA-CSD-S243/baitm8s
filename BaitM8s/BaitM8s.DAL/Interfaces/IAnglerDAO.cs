using BaitM8s.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.Interfaces
{
    public interface IAnglerDAO
    {
        Task<Angler?> GetAnglerAsync(int Id);
        Task<IEnumerable<Angler>> GetAnglersAsync();
    }
}
