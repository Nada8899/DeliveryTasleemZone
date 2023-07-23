using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TasleemDelivery.DTO;
using TasleemDelivery.Models;

namespace TasleemDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string role)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = role;

                IdentityResult identityResult = await _roleManager.CreateAsync(identityRole);
                ResultDTO resultDTO = new ResultDTO();
                if(identityResult.Succeeded)
                {
                    resultDTO.IsPass = true;
                    resultDTO.Message = "Success";

                    return Ok(resultDTO);
                }
                else
                {
                    resultDTO.IsPass = false;
                    resultDTO.Message = "Falied";

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
