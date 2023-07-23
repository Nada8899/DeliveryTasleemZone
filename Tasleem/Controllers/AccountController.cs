using AutoMapper;
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
    public class AccountController : ControllerBase
    {
        UserManager<ApplicationUser> _userManager;
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        AccountService _accountService;
        public AccountController(UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            AccountService accountService)
        {
            _userManager= userManager;
            _mapper= mapper;
            _unitOfWork= unitOfWork;
            _accountService= accountService;
        }

        [HttpPost("DeliveryRegister")]
        public async Task<IActionResult> DeliveryRegister(DeliveryRegisterDTO registerDTO)
        {
            if (ModelState.IsValid) 
            {
                ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(registerDTO);
                IdentityResult identityResult = await _userManager.CreateAsync(applicationUser,registerDTO.Password);

                ResultDTO resultDTO= new ResultDTO();
                if(identityResult.Succeeded)
                {
                     await _userManager.AddToRoleAsync(applicationUser, "Delivery");
                  
                     registerDTO.DeliveryId=applicationUser.Id;

                    _accountService.AddDelivery(registerDTO);
                    _unitOfWork.CommitChanges();

                     resultDTO.IsPass=true;
                     resultDTO.Message = "Success";
                     resultDTO.Data= registerDTO;

                    return Ok(resultDTO);

                }
                else
                {
                    resultDTO.IsPass=false;
                    resultDTO.Message = "Failed";

                    return BadRequest(resultDTO);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
            

        }
    }
}
