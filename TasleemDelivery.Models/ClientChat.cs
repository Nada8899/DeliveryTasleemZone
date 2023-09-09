using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models.InterFaces;

namespace TasleemDelivery.Models
{
    public class ClientChat:IBaseModel<int>
    {
            public int Id { get; set; }

            public string ClientMsg { get; set; }
            public DateTime ClientMsgTime { get; set; }

            [ForeignKey("Client")]
            public string ClientId { get; set; }
            public virtual Client Client { get; set; }

            [ForeignKey("Delivery")]
            public string DeliveryId { get; set; }
            public virtual Delivery Delivery { get; set; }
            [DefaultValue(false)]
            public bool IsDeleted { get; set; }
      }
}
