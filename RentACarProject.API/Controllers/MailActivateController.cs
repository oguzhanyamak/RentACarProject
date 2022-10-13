using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentACarProject.Application.Abstraction.Services;
using System.Web;

namespace RentACarProject.API.Controllers
{

    [ApiController]
    public class MailActivateController : ControllerBase
    {

        private readonly IUserService _userService;

        public MailActivateController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("Authentication/VerifyEmail")]
        public async Task<IActionResult> verify([FromQuery]string userId,string code)
        {
            if(userId == null || code == null)
            {
                return BadRequest();
            }
            else
            {
                IdentityResult res = await _userService.verify(userId, code);
                if (res.Succeeded)
                {
                    return Ok("Confirmed");
                }
                else
                {
                    string message = "";
                    foreach (var error in res.Errors)
                        message += $"{error.Description} - {error.Code}";
                    return BadRequest(message);
                }
            }
        }
    }
}
