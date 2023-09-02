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

    public class ComplaintsAndSuggestionsService
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        public ComplaintsAndSuggestionsService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        public ComplaintsAndSuggestionsDTO Add(ComplaintsAndSuggestionsDTO DTO)
        {

            ComplaintsِnAndSuggestions ComplaintsِnAndSuggestions = _mapper.Map<ComplaintsِnAndSuggestions>(DTO);

            _unitOfWork.ComplaintsِnAndSuggestionsRepository.Add(ComplaintsِnAndSuggestions);
            _unitOfWork.SaveChanges();

            return DTO;
        }



        public List<ComplaintsAndSuggestionsDTO> Get()
        {

           
            IQueryable<ComplaintsِnAndSuggestions> ComplaintsِnAndSuggestions = _unitOfWork.ComplaintsِnAndSuggestionsRepository.GetAll();
            List<ComplaintsAndSuggestionsDTO> DTOs = _mapper.ProjectTo<ComplaintsAndSuggestionsDTO>(ComplaintsِnAndSuggestions).ToList();



            return DTOs;
        }



    }
}
