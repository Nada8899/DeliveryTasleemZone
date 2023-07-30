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
    public class LocationService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public LocationService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public LocationDTO Add (LocationDTO locationDTO)
        {

            Location location = _mapper.Map<Location>(locationDTO);
            _unitOfWork.LocationRepository.Add(location);
            _unitOfWork.SaveChanges();
            return locationDTO;

        }


        public List<LocationDTO> GetLocations()
        {

            IQueryable<Location> locations = _unitOfWork.LocationRepository.GetAll();

            List<LocationDTO> locationDTOs = _mapper.ProjectTo<LocationDTO>(locations).ToList();


            return locationDTOs;

        }
    }
}
