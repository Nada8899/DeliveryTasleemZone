using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
            this._unitOfWork = _unitOfWork;
        }

        [HttpPost("AddLocation")]
        public IActionResult AddLocation(LocationDTO locationDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                LocationDTO location = locationService.AddLocation(locationDTO);
                _unitOfWork.CommitChanges();


                result.Data = location;
                result.IsPass = true;
                result.Message = "Success";

                return Ok(result);
            }
            else
            {
                result.IsPass = false;
                result.Message = "Failed";
                result.Data = ModelState;

                return BadRequest(result);
            }
           
        
        }


        [HttpGet("GetLocation")]
        public IActionResult GetLocation( )
        {

            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                List<LocationDTO> locations = locationService.GetLocations();
                _unitOfWork.CommitChanges();


                result.Data = locations;
                result.IsPass = true;
                result.Message = "Success";

                return Ok(result);
            }

            else
            {
                result.IsPass = false;
                result.Message = "Failed";
                result.Data = ModelState;

                return BadRequest(result);
            }
        }

    }
}
