using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasleemDelivery.Models.InterFaces
{
    public interface IUserConnectionMappingService
    {
        public void AddOrUpdate(string userId, string connectionId);
        public void Remove(string userId);
        public bool TryGetConnectionId(string userId, out string connectionId);

    }
}
