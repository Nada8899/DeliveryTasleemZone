using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasleemDelivery.Models.InterFaces
{
    public interface INotificationService
    {
        Task SendNotificationToFollowersAsync(string userId, Notification notification);
        Task SendNotificationToUserAsync(string userId, Notification notification);
    }
}
