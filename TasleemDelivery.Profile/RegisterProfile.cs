using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TasleemDelivery.DTO;
using TasleemDelivery.Models;

namespace TasleemDelivery.Profiles
{
    public class RegisterProfile:Profile
    {
        public RegisterProfile()
        {
            CreateMap<DeliveryRegisterDTO, ApplicationUser>();
            CreateMap<DeliveryRegisterDTO, Delivery>();
        }
    }
}
