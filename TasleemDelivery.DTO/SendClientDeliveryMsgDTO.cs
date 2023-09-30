using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasleemDelivery.DTO
{
    public class SendClientDeliveryMsgDTO
    {
       public string ClientId { get; set; }
       public string DeliveryId { get; set; }
       public string Msg { get; set; }

    }
}
