using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models;

namespace TasleemDelivery.Repository.Interfaces
{
    public interface IAccountRepository
    {

        string GetQuestionByUserName(string DeliveryId);
    }
}
