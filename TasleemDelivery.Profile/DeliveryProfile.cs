using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.DTO;
using TasleemDelivery.Models;

namespace TasleemDelivery.Profiles
{
    public class DeliveryProfile:Profile
    {
        public DeliveryProfile() 
        {
            CreateMap<DeliveryProfileDTO, Delivery>()
               .ForMember(dst=>dst.ProfileImg,opt=>opt.Ignore())
               .ForMember(dst => dst.EducationLevel, opt => opt.Ignore())
               .ForMember(dst => dst.Languges, opt => opt.Ignore())
               .ForMember(dst => dst.Skills, opt => opt.Ignore());

            CreateMap< Delivery, GetDeliveryProfileDataDTO>()
                  .ForMember(dst => dst.Languges, opt => opt.Ignore())
               .ForMember(dst => dst.Skills, opt => opt.Ignore());

        }
    }
}
