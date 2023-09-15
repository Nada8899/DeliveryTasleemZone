using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.DTO;
using TasleemDelivery.Models;
using TasleemDelivery.Repository.UnitOfWork;

namespace TasleemDelivery.Service
{
    public class ChatService
    {

        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public ChatService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public ChatMessageClientDTO AddClientMsg(ChatMessageClientDTO chatDTO)
        {

            ClientChat chat = _mapper.Map<ClientChat>(chatDTO);

            _unitOfWork.ClientChatRepository.Add(chat);
            _unitOfWork.SaveChanges();

            return chatDTO;
        }
    }
}
