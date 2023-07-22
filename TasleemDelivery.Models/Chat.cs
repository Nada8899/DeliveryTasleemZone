﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models.InterFaces;

namespace TasleemDelivery.Models
{
    public class Chat:IBaseModel<int>
    {
        public int Id { get; set; }

        public string DeliveryMsg { get; set; }
        public string ClientMsg { get; set; }
        public DateTime DeliveryMsgTime { get; set; }
        public DateTime ClientMsgTime { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("Client")]
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("Delivery")]
        public string DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }
    }
}