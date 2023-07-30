using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models;

namespace TasleemDelivery.DTO
{
    public class EducationLevelDTO
    {

        public string Name { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public string DeliveryID { get; set; }

       
    }
}
