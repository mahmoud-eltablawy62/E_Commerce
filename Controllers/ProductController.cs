using ECommerce.Dtos;
using ECommerce.Models;
using ECommerce.Services;

using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServ products;
        public ProductController(IProductServ Products)
        {
            products = Products;
        }

        [HttpGet]
        public async Task<ActionResult> getall()
        {
            var prod = await products.GetAllProduct();
            return Ok(prod);
        }

        [HttpGet("{ID:int}")]
        public async Task<IActionResult> getbyId(int id)
        {
            var prod = await products.GetProductById(id);

            if (prod == null)
                return BadRequest("not found");
            else
                return Ok(prod);
        }

        [HttpGet("category/{cat_id}")]
        public async Task<IActionResult> GetProductByCategory(int cat_id)
        {
            var prod = await products.GetAllProductsbyCategory_Id(cat_id);
            if (prod == null)
            {
                return BadRequest("NotFound");
            }
            else
                return Ok(prod);
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Product>>> Search(string search) { 
           
            return Ok(await products.GetAllbySearchItem(search));
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromForm] ProductDto dto)
        {
            var product = await products.GetProductById(Id);
            if (product == null)
            {
                return BadRequest("not found");
            }

            using var dataStream = new MemoryStream();
            await dto.Photo.CopyToAsync(dataStream);

            product.Cat_id = product.Cat_id;
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Phote = dataStream.ToArray();
            
            product.Price = dto.Price; 
            
            products.Update(product);
            return Ok(product);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var proudct = await products.GetProductById(Id);    
            if (proudct == null) {
                return BadRequest("not found");
            }
            products.Delete(proudct);
            return Ok(proudct); 
        }
    }
}



