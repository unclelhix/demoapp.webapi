using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Services;
using DemoApplication.WebAPI.Transports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeAPIController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost(template: nameof(AddEmployee), Name = nameof(AddEmployee))]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeTransport employee)
        {
            if (employee == null)            
                return BadRequest("Employee is null.");
            
            bool result = await _employeeService.Add(employee);

            return Ok(result);
        }
        [HttpPatch(template: nameof(UpdateEmployee), Name = nameof(UpdateEmployee))]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeTransport employee)
        {
            if (employee == null)            
                return BadRequest("Employee is null.");
            

            bool result = await _employeeService.Update(employee);

            return Ok(result);
        }

        [HttpGet(template: nameof(GetAllEmployees), Name = nameof(GetAllEmployees))]
        public async Task<IActionResult> GetAllEmployees()
        {
            IEnumerable<EmployeeTransport> employees = await _employeeService.GetAll();

            return Ok(employees);
        }


        [HttpGet(template: "GetEmployeeById/{id}", Name = nameof(GetEmployeeById))]
        public async Task<IActionResult> GetEmployeeById(long id)
        {
            EmployeeTransport employee = await _employeeService.GetById(id);

            if (employee == null)            
                return NotFound("The Employee record couldn't be found.");
            
            return Ok(employee);
        }


       
    }
}
