using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIIntro.Models;

namespace WebAPIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public List<Product> GetAll()
        {
            NorthwndContext db = new NorthwndContext();
            List<Product>products = db.Products.ToList();
            return products;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            NorthwndContext db = new NorthwndContext();
            Product product = db.Products.FirstOrDefault(x=> x.ProductId == id);
            return product;
        }
    }
}
