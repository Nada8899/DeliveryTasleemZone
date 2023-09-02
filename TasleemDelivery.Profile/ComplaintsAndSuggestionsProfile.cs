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
    public class ComplaintsAndSuggestionsProfile : Profile
    {
        public ComplaintsAndSuggestionsProfile()
        {
            CreateMap<ComplaintsAndSuggestionsDTO, ComplaintsِnAndSuggestions>();
            //.ForMember(dst => dst.ApplicationUserId, opt => opt.Ignore());

            CreateMap<ComplaintsِnAndSuggestions, ComplaintsAndSuggestionsDTO>();
               //.ForMember(dst => dst.ApplicationUserId, opt => opt.Ignore());
        }
    }
}
