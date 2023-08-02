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
    public class EduactionLevelProfile:Profile
    {
        public EduactionLevelProfile()
        {
            CreateMap<EducationLevelDTO, EducationLevel>().ReverseMap();
        }
    }
}
