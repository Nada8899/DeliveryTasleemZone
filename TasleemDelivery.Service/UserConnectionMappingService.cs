using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models.InterFaces;

namespace TasleemDelivery.Service
{
    public class UserConnectionMappingService : IUserConnectionMappingService
    {
        private readonly Dictionary<string, string> _userConnectionMap = new Dictionary<string, string>();

        public void AddOrUpdate(string userId, string connectionId)
        {
            _userConnectionMap[userId] = connectionId;
        }

        public bool TryGetConnectionId(string userId, out string connectionId)
        {
            return _userConnectionMap.TryGetValue(userId, out connectionId);
        }

        public void Remove(string userId)
        {
            _userConnectionMap.Remove(userId);
        }


    }
}
