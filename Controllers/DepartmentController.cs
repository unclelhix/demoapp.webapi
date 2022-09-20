using DemoApplication.WebAPI.Services;
using DemoApplication.WebAPI.Transports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost(template: nameof(AddDepartment), Name = nameof(AddDepartment))]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentTransport transport)
        {
            if (transport == null)
                return BadRequest("Employee is null.");

            bool result = await _departmentService.Add(transport);

            return Ok(result);
        }

        [HttpPatch(template: nameof(UpdateDepartment), Name = nameof(UpdateDepartment))]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentTransport transport)
        {
            if (transport == null)
                return BadRequest("Employee is null.");


            bool result = await _departmentService.Update(transport);

            return Ok(result);
        }

        [HttpGet(template: nameof(GetAllDepartment), Name = nameof(GetAllDepartment))]
        public async Task<IActionResult> GetAllDepartment()
        {
            IEnumerable<DepartmentTransport> employees = await _departmentService.GetAll();

            return Ok(employees);
        }

        [HttpGet(template: "GetDepartmentById/{id}", Name = nameof(GetDepartmentById))]
        public async Task<IActionResult> GetDepartmentById(long id)
        {
            DepartmentTransport employee = await _departmentService.GetById(id);

            if (employee == null)
                return NotFound("The Employee record couldn't be found.");

            return Ok(employee);
        }

    }
}
