using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasleemDelivery.DTO;
using TasleemDelivery.Repository.UnitOfWork;
using TasleemDelivery.Service;

namespace TasleemDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        ClientService _clientService;
        IUnitOfWork _unitOfWork;
        public ClientController(ClientService clientService, IUnitOfWork unitOfWork)
        {
            _clientService= clientService;
            _unitOfWork= unitOfWork;
        }

        [HttpPut("AddClientProfile")]
        public IActionResult AddClientProfile([FromForm] ClientProfileDTO clientProfileDTO, [FromForm] params string[] properties)

        {
            ResultDTO resultDTO = new ResultDTO();

            if (ModelState.IsValid)
            {
                ClientProfileDTO ClientProfileDTO = _clientService.AddClientProfile(clientProfileDTO, properties);
                _unitOfWork.CommitChanges();

                resultDTO.Message = "Success";
                resultDTO.IsPass = true;
                resultDTO.Data = ClientProfileDTO;

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



        [HttpGet("GetClientProfileData/ClientId")]
        public IActionResult AddClientProfile(string clientId)
        {
            ResultDTO resultDTO = new ResultDTO();

            if (ModelState.IsValid)
            {
                GetClientProfileDataDTO ClientProfileDTO = _clientService.GetClientProfileDataDTO(clientId);

                resultDTO.Message = "Success";
                resultDTO.IsPass = true;
                resultDTO.Data = ClientProfileDTO;

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
