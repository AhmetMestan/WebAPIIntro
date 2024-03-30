using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIIntro.Models;

namespace WebAPIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            NorthwndContext db = new NorthwndContext();
            List<Supplier> suppliers = db.Suppliers.ToList();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            NorthwndContext db = new NorthwndContext();
            Supplier supplier = db.Suppliers.FirstOrDefault(x=>x.SupplierId== id);

            if(supplier == null)
            {
                return NotFound("Böyle bir category mevcut değil.");
            }
            return Ok(supplier);
        }
    }
}
