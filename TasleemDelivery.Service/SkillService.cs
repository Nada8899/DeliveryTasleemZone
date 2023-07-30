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
    public class SkillService
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        public SkillService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper= mapper;
            _unitOfWork= unitOfWork;
        }

        public void AddSkill(string skillName,string DeliveryID)
        {
           Skill skill= new Skill()
           {
               Name= skillName,
               DeliveryID= DeliveryID
           };

            _unitOfWork.SkillRepository.Add(skill);
            _unitOfWork.SaveChanges();

        }
    }
}
