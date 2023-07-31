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
    public class ClientProfile:Profile
    {
       public ClientProfile()
        {
            CreateMap<ClientProfileDTO,Client>()
                .ForMember(src=>src.ProfileImg,opt=>opt.Ignore())
                .ForMember(src=>src.Languges,opt=>opt.Ignore());
        }
    }
}
