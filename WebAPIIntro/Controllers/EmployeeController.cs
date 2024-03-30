using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIIntro.Models;

namespace WebAPIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            NorthwndContext db = new NorthwndContext();
            List<Employee> employees = db.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            NorthwndContext db = new NorthwndContext();
            Employee employee = db.Employees.FirstOrDefault(x => x.EmployeeId == id);

            if(employee == null)
            {
                return NotFound("Böyle bir Employee bulunmamakatdır.");
            }

            return Ok(employee);
        }
    }
}
