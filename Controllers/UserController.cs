using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffApplication2.DTOs;
using StaffApplication2.Services;
using System.Text;
using Newtonsoft.Json;

namespace StaffApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser request)
        {
            var resp = await _userService.CreateUser(request);

          return Ok(resp);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUser request)
        {
            var resp = await _userService.UpdateUser(request);

            return Ok(resp);
        }

        [HttpPut("LogInUser")]
        public async Task<IActionResult> LogInUser(EmailandPassword request)
        {
            var resp = await _userService.LogInUser(request);

            return Ok(resp);
        }

        [HttpPut("LogOutUser")]
        public async Task<IActionResult> LogOutUser(EmailandPassword request)
        {
            var resp = await _userService.LogOutUser(request);

            return Ok(resp);
        }

        [HttpPut("DeActivateUser")]
        public async Task<IActionResult> DeActivater(DeactivateUser  request)
        {
            var resp = await _userService.DeActivate(request);

            return Ok(resp);
        }

        [HttpPut("ReActivateUser")]
        public async Task<IActionResult> ReActivater(ReactivateUser request)
        {
            var resp = await _userService.ReActivate(request);

            return Ok(resp);
        }


        [HttpGet("FindUserbyEmail")]

        public async Task<IActionResult> FindUserbyEmail([FromQuery] string userEmail)
        {
            var resp = await _userService.FindUser(userEmail);
            return Ok(resp);
        }

        [HttpGet("FindUserbyId")]

        public async Task<IActionResult> FindUserbyId([FromQuery] long userId)
        {
            var resp = await _userService.FindUser(userId);
            return Ok(resp);
        }


        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetUser()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }


        [HttpGet("GetAllActiveUsers")]
        public async Task<IActionResult> GetActiveUsers()
        {
            var users = await _userService.GetAllActiveUsers();
            return Ok(users);
        }
    }
}
