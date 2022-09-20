using DemoApplication.WebAPI.Services;
using DemoApplication.WebAPI.Transports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentGroupController : ControllerBase
    {
        private readonly IDepartmentGroupService _departmentGroupService;
        public DepartmentGroupController(IDepartmentGroupService departmentGroupService)
        {
            _departmentGroupService = departmentGroupService;
        }

        [HttpGet(template: "GetByDepartmentId/{id}", Name = nameof(GetByDepartmentId))]
        public async Task<IActionResult> GetByDepartmentId(long id)
        {
            var departmentGroup = await _departmentGroupService.GetByDepartmentId(id);

            if (departmentGroup == null)
                return NotFound("The Employee record couldn't be found.");

            return Ok(departmentGroup);
        }
    }
}
