using DemoApplication.WebAPI.DatabaseContext;
using DemoApplication.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        //public EmployeeController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //[HttpGet(template: nameof(GetEmployees), Name = nameof(GetEmployees))]
        //public IActionResult GetEmployees()
        //{
        //    return Ok(_context.Employee.ToList());
        //}
        //[HttpGet(template: nameof(GetEmployeeById), Name = nameof(GetEmployeeById))]
        //public IActionResult GetEmployeeById(long id)
        //{
        //    var result = _context.Employee
        //        .Include(x => x.EmployeeGovernmentNumbers)
        //        .Include(x => x.EmployeeContacts)
        //        .Where(x => x.Id == id).FirstOrDefault();

        //    return Ok(result);
        //}
        //Success:

        //return Ok() ← Http status code 200
        //return Created() ← Http status code 201
        //return NoContent(); ← Http status code 204

        //Client Error:

        //return BadRequest(); ← Http status code 400
        //return Unauthorized(); ← Http status code 401
        //return NotFound(); ← Http status code 404
    }
}
