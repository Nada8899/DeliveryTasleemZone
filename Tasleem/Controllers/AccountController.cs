using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        IConfiguration _configuration;
        UserManager<ApplicationUser> _userManager;
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        AccountService _accountService;
        public AccountController(UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            AccountService accountService)
        {
            _userManager= userManager;
            _configuration= configuration;
            _mapper= mapper;
            _unitOfWork= unitOfWork;
            _accountService= accountService;
        }

        [HttpPost("DeliveryRegister")]
        public async Task<IActionResult> DeliveryRegister(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid) 
            {

                ApplicationUser existingUser = await _userManager.FindByNameAsync(registerDTO.UserName);
                if (existingUser != null)
                {
                    ResultDTO result = new ResultDTO
                    {
                        Message = "Duplicate UserName",
                        IsPass = false,
                    };
                    return Ok(result);
                }

                ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(registerDTO);
                IdentityResult identityResult = await _userManager.CreateAsync(applicationUser,registerDTO.Password);

                ResultDTO resultDTO= new ResultDTO();
                if(identityResult.Succeeded)
                {
                    try
                    {
                        await _userManager.AddToRoleAsync(applicationUser, "Delivery");

                    }
                    catch (Exception ex)
                    {
                        resultDTO.IsPass = false;
                        resultDTO.Message = "Failed to assign role to the user,Role doesn't exist";


                        return BadRequest(resultDTO);
                    }
                    registerDTO.Id=applicationUser.Id;

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
                    resultDTO.Data = identityResult;

                    return BadRequest(resultDTO);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
            

        }
        [HttpPost("ClientRegister")]
        public async Task<IActionResult> ClientRegister(RegisterDTO registerDTO)
        {

            if (ModelState.IsValid)
            {

                ApplicationUser existingUser = await _userManager.FindByNameAsync(registerDTO.UserName);
                if (existingUser != null)
                {
                    ResultDTO result = new ResultDTO
                    {
                        Message = "Duplicate UserName",
                        IsPass = false,
                    };
                    return Ok(result);
                }

                ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(registerDTO);
                IdentityResult identityResult = await _userManager.CreateAsync(applicationUser, registerDTO.Password);

                ResultDTO resultDTO = new ResultDTO();
                if (identityResult.Succeeded)
                {
                    try
                    {
                        await _userManager.AddToRoleAsync(applicationUser, "Client");

                    }
                    catch (Exception ex)
                    {
                        resultDTO.IsPass = false;
                        resultDTO.Message = "Failed to assign role to the user,Role doesn't exist";


                        return BadRequest(resultDTO);
                    }
                    registerDTO.Id = applicationUser.Id;

                    _accountService.AddClient(registerDTO);
                    _unitOfWork.CommitChanges();

                    resultDTO.Message = "Success";
                    resultDTO.IsPass = true;
                    resultDTO.Data = registerDTO;

                    return Ok(resultDTO);

                }
                else
                {
                    resultDTO.Message = "Failed";
                    resultDTO.IsPass = false;
                    resultDTO.Data = identityResult;

                    return BadRequest(resultDTO);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPost("AdminRegister")]
        public async Task<IActionResult> AdminRegister(RegisterDTO registerDTO)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser exstingUser= await _userManager.FindByNameAsync(registerDTO.UserName);

                if(exstingUser!=null)
                {
                    ResultDTO result = new ResultDTO
                    {
                        Message = "Duplicate UserName",
                        IsPass = false,
                    };

                    return Ok(result);
                }

                ApplicationUser applicationUser=_mapper.Map<ApplicationUser>(registerDTO);
                IdentityResult identityResult=await _userManager.CreateAsync(applicationUser, registerDTO.Password);

                ResultDTO resultDTO = new ResultDTO();
                if(identityResult.Succeeded)
                {
                    try
                    {
                        await _userManager.AddToRoleAsync(applicationUser, "Admin");

                    }
                    catch (Exception ex)
                    {
                        resultDTO.IsPass = false;
                        resultDTO.Message = "Failed to assign role to the user,Role doesn't exist";


                        return BadRequest(resultDTO);
                    }
                    registerDTO.Id = applicationUser.Id;

                    _accountService.AddAdmin(registerDTO);
                    _unitOfWork.CommitChanges();

                    resultDTO.IsPass = true;
                    resultDTO.Message = "Success";
                    resultDTO.Data = registerDTO;

                    return Ok(resultDTO);

                }
                else
                {
                    resultDTO.IsPass = false;
                    resultDTO.Message = "Failed";
                    resultDTO.Data = identityResult;


                    return BadRequest(resultDTO);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPost("SubAdminRegister")]
        public async Task<IActionResult> SubAdminRegister(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser exsistingUser = await _userManager.FindByNameAsync(registerDTO.UserName);

                if (exsistingUser != null)
                {
                    ResultDTO result = new ResultDTO
                    {
                        Message = "Duplicate UserName",
                        IsPass = false,
                    };

                    return Ok(result);
                }

                ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(registerDTO);
                IdentityResult identityResult = await _userManager.CreateAsync(applicationUser, registerDTO.Password);

                ResultDTO resultDTO = new ResultDTO();
                if (identityResult.Succeeded)
                {
                    try
                    {
                        await _userManager.AddToRoleAsync(applicationUser, "SubAdmin");

                    }
                    catch(Exception ex)
                    {
                        resultDTO.IsPass = false;
                        resultDTO.Message = "Failed to assign role to the user,Role doesn't exist";
                       

                        return BadRequest(resultDTO);
                    }

                    registerDTO.Id = applicationUser.Id;

                    _accountService.AddSubAdmin(registerDTO);
                    _unitOfWork.CommitChanges();

                    resultDTO.IsPass = true;
                    resultDTO.Message = "Success";
                    resultDTO.Data = registerDTO;

                    return Ok(resultDTO);

                }
                else
                {
                    resultDTO.IsPass = false;
                    resultDTO.Message = "Failed";
                    resultDTO.Data = identityResult;


                    return BadRequest(resultDTO);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDTO LoginUserDto)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = await _userManager.FindByNameAsync(LoginUserDto.UserName);//.FindByNameAsync(userDto.UserName);
                ResultDTO resultDTO=new ResultDTO();

                if (applicationUser != null && await _userManager.CheckPasswordAsync(applicationUser, LoginUserDto.Password))
                {

                    var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                    SigningCredentials credentials = new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256);

                    List<Claim> myClaims = new List<Claim>();

                    myClaims.Add(new Claim(ClaimTypes.NameIdentifier, applicationUser.Id));
                    myClaims.Add(new Claim(ClaimTypes.Name, applicationUser.UserName));
                    myClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    if (await _userManager.IsInRoleAsync(applicationUser, "Delivery"))
                    {
                        myClaims.Add(new Claim(ClaimTypes.Role, "Delivery"));
                    }
                    else if (await _userManager.IsInRoleAsync(applicationUser, "Admin"))
                    {
                        myClaims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    }
                    else if (await _userManager.IsInRoleAsync(applicationUser, "Client"))
                    {
                        myClaims.Add(new Claim(ClaimTypes.Role, "Client"));
                    }
                    else if (await _userManager.IsInRoleAsync(applicationUser, "SubAdmin"))
                    {
                        myClaims.Add(new Claim(ClaimTypes.Role, "SubAdmin"));
                    }
                    else
                    {
                        myClaims.Add(new Claim(ClaimTypes.Role, "NoRole"));
                    }

                    JwtSecurityToken MyToken = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(6),
                    claims: myClaims,


                    signingCredentials: credentials
                    );
                    resultDTO.Message = "Success";
                    resultDTO.IsPass = true;

                    Claim roleClaim=myClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
                    string userRole=roleClaim?.Value ?? "NoRole";
                    return Ok(
                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(MyToken),
                            expiration = MyToken.ValidTo,
                            Messege = "Success",
                            Role = userRole,
                        });

                }
                else
                {
                    resultDTO.Message = "Invalid UserName";
                    resultDTO.IsPass = false;
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
