using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffApplication2.DTOs;
using StaffApplication2.Services;

namespace StaffApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpPost("CreateEmployeeDetails")]

        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployee request)
        {
            var resp = await _employeeService.CreateEmployee(request);

            return Ok(resp);
        }

        [HttpPut("UpdateEmployeeDetails")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployee request)
        {
            var resp = await _employeeService.UpdateEmployee(request);

            return Ok(resp);
        }

        [HttpDelete("DeleteEmployeeDetails")]
        public async Task<IActionResult> DeleteEmployee(DeleteEmployee request)
        {
            var resp = await _employeeService.DeleteEmployee(request);

            return Ok(resp);
        }

        [HttpGet("FindEmployeebyEmail")]
        public async Task<IActionResult> FindEmployeebyEmail([FromQuery] string email)
        {
            var resp = await _employeeService.FindEmployee(email);
            return Ok(resp);

        }

        [HttpGet("FindEmployeebyId")]
        public async Task<IActionResult> FindEmployeebyId([FromQuery] long userId)
        {
            var resp = await _employeeService.FindEmployee(userId);
            return Ok(resp);
        }

        [HttpGet("GetAllActiveEmployee")]
        public async Task<IActionResult> GetAllActiveEmployee()
        {
            return Ok(await _employeeService.GetAllActiveEmployee());
        }

        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            return Ok(await _employeeService.GetAllEmployee());
        }

    }
}
