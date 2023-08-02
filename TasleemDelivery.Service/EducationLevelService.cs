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
    public class EducationLevelService
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;

        public EducationLevelService(IMapper mapper, IUnitOfWork unitOfWork) 
        {
            _mapper= mapper;
            _unitOfWork= unitOfWork;
        }

        public EducationLevel AddEducationLevel(EducationLevelDTO educationLevelDTO,string DeliveryId)
        {
            EducationLevel educationLevel=_mapper.Map<EducationLevel>(educationLevelDTO);
            educationLevel.DeliveryID= DeliveryId;

            if (educationLevelDTO.DateFrom > educationLevelDTO.DateTo)
            {
                _unitOfWork.EducationLevelRepository.Add(educationLevel);
                _unitOfWork.SaveChanges();
            }

            return educationLevel;
        }
        public EducationLevelDTO GetEducationLevelByDeliveryId(string deliveryId)
        {
          EducationLevel educationLevel= _unitOfWork.EducationLevelRepository.GetByExpression(edu => edu.DeliveryID == deliveryId).FirstOrDefault();
          EducationLevelDTO educationLevelDTO= _mapper.Map<EducationLevelDTO>(educationLevel);

            return educationLevelDTO;
        }
    }
}
