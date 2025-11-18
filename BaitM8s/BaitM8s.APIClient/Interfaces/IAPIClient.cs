using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.APIClient.Interfaces
{
    public interface IAPIClient<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetOneAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<int> CreateAsync(T entity);
    }
}
