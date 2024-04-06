using DesafioBackEndVonBraun.Service.DTOs.Auth;
using DesafioBackEndVonBraun.Service.Interfaces.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net;

namespace DesafioBackEndVonBraun.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _UserService = userService;

        [HttpPost("create-test-user")]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody] UserDTO userDTO)
        {

            _UserService.CreateUser(userDTO);
            return Ok();
        }

        [HttpGet("get-test-user/{cpf}")]
        [AllowAnonymous]
        public IActionResult GetUser(string cpf)
        {
            var user = _UserService.GetUser(cpf);
            return Ok(user);
        }

    }
}
