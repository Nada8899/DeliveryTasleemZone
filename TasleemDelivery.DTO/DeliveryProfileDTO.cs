using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models;

namespace TasleemDelivery.DTO
{
    public class DeliveryProfileDTO
    {
        public string Id { get; set; }      
        public string FullName { get; set; }
        public string Address { get; set; }
        public IFormFile ProfileImg { get; set; }
        public string OverView { get; set; }
        public double YearExperinces { get; set; }
       
        public virtual EducationLevelDTO EducationLevelDTO { get; set; }
        public virtual IEnumerable<string> Skills { get; set; }
        public virtual IEnumerable<string> Languges { get; set; }






    }
}
