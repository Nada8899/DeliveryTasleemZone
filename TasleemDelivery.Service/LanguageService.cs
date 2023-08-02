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
    public class LanguageService
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        public LanguageService(IMapper mapper, IUnitOfWork unitOfWork) 
        {
            _mapper= mapper;
            _unitOfWork= unitOfWork;
        }

        public void AddLanguage(string languageName,string ApplicationUserID)
        {
            Language language=new Language()
            {
                Name= languageName,
                ApplicationUserID = ApplicationUserID,
            };

            _unitOfWork.LanguageRepository.Add(language);
            _unitOfWork.SaveChanges();

        }
        public List<string> GetLanguagessByDeliveryID(string deliveryID)
        {
            List<Language> languages = _unitOfWork.LanguageRepository.GetByExpression(lan=>lan.ApplicationUserID == deliveryID).ToList();

            
                List<string> LanguagesNames = new List<string>();
                foreach (Language language in languages)
                {
                LanguagesNames.Add(language.Name);
                }

                return LanguagesNames;
            
        }
    }
}
