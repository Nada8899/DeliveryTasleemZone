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
    public class ClientService
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        LanguageService _languageService;
        public ClientService(IMapper mapper, IUnitOfWork unitOfWork
            , LanguageService languageService)
        {
          _mapper= mapper;
          _unitOfWork= unitOfWork;
          _languageService= languageService;
        }

        public ClientProfileDTO AddClientProfile(ClientProfileDTO clientProfileDTO,params string[] properties)
        {
            Client client=_mapper.Map<Client>(clientProfileDTO);
            client.ApplicationUser=new ApplicationUser();
            if (clientProfileDTO.ProfileImg != null)
            {
                using var dataStream = new MemoryStream();
                clientProfileDTO.ProfileImg.CopyTo(dataStream);
                client.ProfileImg = dataStream.ToArray();
                client.ApplicationUser.ProfileImg=dataStream.ToArray();
            }          

            _unitOfWork.ClientRepository.Update(client,properties);
            _unitOfWork.SaveChanges();

            if(clientProfileDTO.Languges != null) 
            {
                foreach(string languge in clientProfileDTO.Languges)
                {
                    _languageService.AddLanguage(languge, client.Id);

                }
            }
            return clientProfileDTO;
        }
    }
}
