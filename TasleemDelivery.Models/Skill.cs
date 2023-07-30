﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models.InterFaces;

namespace TasleemDelivery.Models
{
    public class Skill :IBaseModel<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [ForeignKey("Delivery")]
        public string DeliveryID { get; set; }

        public virtual Delivery Delivery { get; set; }
    }
}
