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

        [HttpPost]
        public IActionResult PostSupplier(Supplier supplier)
        {
            NorthwndContext db = new NorthwndContext();
            db.Suppliers.Add(supplier);
            db.SaveChanges();

            return Ok("Ekleme işlmei başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            NorthwndContext db = new NorthwndContext();
            Supplier supplier = db.Suppliers.FirstOrDefault(x=>x.SupplierId== id);

            if(supplier == null)
            {
                return NotFound();
            }

            db.Suppliers.Remove(supplier);
            db.SaveChanges();

            return Ok("Silme işlemi başarılı");

        }

        [HttpPut]
        public IActionResult PutSupplier(Supplier supplier)
        {
            NorthwndContext db = new NorthwndContext();
            Supplier entitiy = db.Suppliers.FirstOrDefault(x=>x.SupplierId == supplier.SupplierId);

            entitiy.CompanyName = supplier.CompanyName;
            entitiy.ContactName = supplier.ContactName;
            entitiy.ContactTitle = supplier.ContactTitle;

            db.SaveChanges();

            return Ok("Güncelleme işlemi başarılı");
        }

    }
}
