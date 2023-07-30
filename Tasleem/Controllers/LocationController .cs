using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TasleemDelivery.DTO;
using TasleemDelivery.Models;
using TasleemDelivery.Repository.UnitOfWork;
using TasleemDelivery.Service;

namespace TasleemDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        IUnitOfWork _unitOfWork;

        LocationService locationService;
        
        public LocationController( LocationService locationService , IUnitOfWork _unitOfWork)
        {
          
            this.locationService = locationService;
            this. _unitOfWork = _unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation(LocationDTO locationDTO)
        {
           
           LocationDTO l=  locationService.Add(locationDTO);
            _unitOfWork.CommitChanges();
            return Ok(new
            {
                data=l,
                msg="Added"
            });
        }


        [HttpGet("GetLocation")]
        public async Task<IActionResult> GetLocation( )
        {

            List<LocationDTO> l = locationService.GetLocations();

            return Ok(l);
                 }

    }
}
