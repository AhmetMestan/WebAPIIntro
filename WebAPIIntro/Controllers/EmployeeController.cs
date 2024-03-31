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

        [HttpPost]
        public IActionResult PostEmployee(Employee employee)
        {
            NorthwndContext db = new NorthwndContext();
            db.Employees.Add(employee);
            db.SaveChanges();

            return Ok("Employe ekleem işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            NorthwndContext db = new NorthwndContext();
            Employee employee = db.Employees.Find(id);

            if (employee == null)
            {
                return NotFound("Böyle bir Employee bulunamamıştır");
            }

            db.Employees.Remove(employee);
            db.SaveChanges();
            return Ok("Employee başarı ile silinmiştir");
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            NorthwndContext db = new NorthwndContext();
            Employee entity = db.Employees.FirstOrDefault(x=>x.EmployeeId== employee.EmployeeId);

            if (entity == null)
            {
                return NotFound("Böyle bir employee bulunamamıştır");
            }

            entity.FirstName= employee.FirstName;
            entity.LastName= employee.LastName;
            entity.Title= employee.Title;
            db.SaveChanges();

            return Ok("Güncelleme başarı ile yapılmıştır");


        }
    }
}
