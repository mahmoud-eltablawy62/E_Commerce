
using ECommerce.Services;

using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServ products;
        public CategoryController(ICategoryServ Products)
        {
            products = Products;
        }

        [HttpGet]
        public async Task<ActionResult> getall()
        {
            var prod = await products.GetAllCategories();
            return Ok(prod);
        }

    }
}
