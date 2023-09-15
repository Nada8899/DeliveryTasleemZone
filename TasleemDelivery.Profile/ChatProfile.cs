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
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<ChatMessageClientDTO, ClientChat>();

            CreateMap<ClientChat, ChatMessageClientDTO>();
        }



    }
}
