using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.Services.Notifications.Interfaces
{
    public interface INotificationService
    {
        Task<bool> SendNotificationAsync(string Message);
    }
}
