using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasleemDelivery.DTO;
using TasleemDelivery.Repository.UnitOfWork;
using TasleemDelivery.Service;

namespace TasleemDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeiveryController : ControllerBase
    {
        DeliveryService _deliveryService;
        IUnitOfWork _unitOfWork;
        public DeiveryController(DeliveryService deliveryService, IUnitOfWork unitOfWork)
        {
            _deliveryService= deliveryService;
            _unitOfWork= unitOfWork;
        }

        [HttpPut("AddDeliveryProfile")]
        public IActionResult AddDeliveryProfile([FromForm]DeliveryProfileDTO deliveryProfileDTO,[FromForm] params string[] properties)
        {
            ResultDTO resultDTO = new ResultDTO();

            if (ModelState.IsValid)
            {
                DeliveryProfileDTO DeliveryProfileDTO=_deliveryService.AddDeliveryProfile(deliveryProfileDTO,properties);
                _unitOfWork.CommitChanges();

                resultDTO.Message = "Success";
                resultDTO.IsPass = true;
                resultDTO.Data = DeliveryProfileDTO;

                return Ok(resultDTO);
            }
            else
            {
                resultDTO.Message = "Failed";
                resultDTO.IsPass = false;
                resultDTO.Data = ModelState;
                return BadRequest(resultDTO);
            }
        }
        [HttpGet("GetDeliveryProfileData/{deliveryID}")]
        public IActionResult AddDeliveryProfile(string deliveryID)
        {
            ResultDTO resultDTO = new ResultDTO();

            if (ModelState.IsValid)
            {
                GetDeliveryProfileDataDTO DeliveryProfileDTO = _deliveryService.GetDeliveryProfileData(deliveryID);

                resultDTO.Message = "Success";
                resultDTO.IsPass = true;
                resultDTO.Data = DeliveryProfileDTO;

                return Ok(resultDTO);
            }
            else
            {
                resultDTO.Message = "Failed";
                resultDTO.IsPass = false;
                resultDTO.Data = ModelState;
                return BadRequest(resultDTO);
            }
        }

    }
}
