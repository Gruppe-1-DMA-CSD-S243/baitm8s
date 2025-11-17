using BaitM8s.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.Interface
{
    public interface IAnglerDAO
    {
        Angler? GetAngler(int id);
        IEnumerable<Angler> GetAnglers();

    }
}
