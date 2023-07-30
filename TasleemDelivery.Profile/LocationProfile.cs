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
    public class LocationProfile:Profile
    {
        public LocationProfile() {

            CreateMap<LocationDTO, Location>();
            CreateMap<Location, LocationDTO>()
                .ForMember(src=>src.Id,opt=>opt.Ignore());

        }
    }
}
