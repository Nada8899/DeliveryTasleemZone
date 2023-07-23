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
    public class AccountService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public AccountService(IMapper mapper,IUnitOfWork unitOfWork) 
        {
            _unitOfWork= unitOfWork;
            _mapper= mapper;
        }

        public DeliveryRegisterDTO AddDelivery(DeliveryRegisterDTO registerDTO)
        {
            Delivery delivery = _mapper.Map<Delivery>(registerDTO);
            delivery.Id = registerDTO.DeliveryId;
            _unitOfWork.DeliveryRepository.Add(delivery);
            _unitOfWork.SaveChanges();

            return registerDTO;
        }
    }
}
