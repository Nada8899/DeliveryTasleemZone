using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models;

namespace TasleemDelivery.DTO
{
    public class ChatMessageClientDTO
    {
        public string ClientMsg { get; set; }
        public DateTime? ClientMsgTime { get; set; }

        public string ClientId { get; set; }
        public string DeliveryId { get; set; }


    }
}
