using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models;
using Microsoft.AspNetCore.Http;

namespace TasleemDelivery.DTO
{
    public class ClientProfileDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }      
        public string Address { get; set; }
        public IFormFile ProfileImg { get; set; }      
        public string OverView { get; set; }
        public List<string> Languges { get; set; }

     
    }
}
