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
    public class DeliveryService
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        EducationLevelService _educationLevelService;
        LanguageService _languageService;
        SkillService _skillService;
        public DeliveryService(IMapper mapper, IUnitOfWork unitOfWork,
                    EducationLevelService educationLevelService,
                            LanguageService languageService,
                                    SkillService skillService)
        {
            _mapper= mapper;
            _unitOfWork= unitOfWork;
            _educationLevelService= educationLevelService;
            _languageService = languageService;
            _skillService= skillService;
        }

        public DeliveryProfileDTO AddDeliveryProfile(DeliveryProfileDTO deliveryProfileDTO, params string[] properties)
        {
            Delivery delivery = _mapper.Map<Delivery>(deliveryProfileDTO);
            if (deliveryProfileDTO.ProfileImg != null)
            {
                using var dataStream = new MemoryStream();
                deliveryProfileDTO.ProfileImg.CopyTo(dataStream);

                if(delivery.ApplicationUser==null)
                {
                    delivery.ApplicationUser = new ApplicationUser();   
                }
                delivery.ApplicationUser.ProfileImg = dataStream.ToArray();
                delivery.ProfileImg = dataStream.ToArray();
            }

            EducationLevel educationLevel = _educationLevelService.AddEducationLevel(deliveryProfileDTO.EducationLevelDTO, delivery.Id);
            delivery.EducationLevelID = educationLevel.Id;

            _unitOfWork.DeliveryRepository.Update(delivery, properties);
            _unitOfWork.SaveChanges();

            if(deliveryProfileDTO.Skills != null ) 
            {
                foreach (string skillName in deliveryProfileDTO.Skills)
                {
                    _skillService.AddSkill(skillName, delivery.Id);

                }
            }

            if (deliveryProfileDTO.Languges != null)
            {
                foreach (string languageName in deliveryProfileDTO.Languges)
                {
                    _languageService.AddLanguage(languageName, delivery.Id);
                }
            }


            return deliveryProfileDTO;

        }
        public GetDeliveryProfileDataDTO GetDeliveryProfileData(string DeliveryId)
        {
            Delivery delivery=_unitOfWork.DeliveryRepository.GetByID(DeliveryId,"Skills", "Languges", "EducationLevel");

            GetDeliveryProfileDataDTO deliveryDTO = _mapper.Map<GetDeliveryProfileDataDTO>(delivery);

            deliveryDTO.Skills=_skillService.GetSkillsByDeliveryID(DeliveryId).ToList();
            deliveryDTO.Languges=_languageService.GetLanguagessByDeliveryID(DeliveryId).ToList();
            deliveryDTO.EducationLevelDTO = _educationLevelService.GetEducationLevelByDeliveryId(DeliveryId);


            return deliveryDTO;
        }
    }
}
