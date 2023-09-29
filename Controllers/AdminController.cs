using ECommerce.Dtos;
using ECommerce.Models;
using ECommerce.Services;

using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IA_Con Serv;
       
        public AdminController(IA_Con _Serv )
        {
            Serv = _Serv;
            
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CategoryDto dto)
        {
            using var dataStream = new MemoryStream();
            await dto.Photo.CopyToAsync(dataStream);

            var categories = new Category
            {
                Name = dto.Name,
                Description = dto.Description,
                Photo = dataStream.ToArray(),
            };
            await Serv.Addcategory(categories);
            return Ok(categories);
        }


        [HttpPost]
        [Route("category/{category_id}")]
        public async Task<IActionResult> addProduct([FromForm] ProductDto product, int category_id)
        {
            using var dataStream = new MemoryStream();
            await product.Photo.CopyToAsync(dataStream);
            var products = new Product
            {
                Phote = dataStream.ToArray(),
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Cat_id = category_id,
                
            };
            await Serv.Addproduct(products);
            return Ok(products);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromForm] CategoryDto dto)
        {
            var category = await Serv.Getbyid(Id);
            if (category == null)
            {
                return BadRequest("not found");
            }

            using var dataStream = new MemoryStream();
            await dto.Photo.CopyToAsync(dataStream);


            category.Name = dto.Name;
            category.Description = dto.Description;
            category.Photo = dataStream.ToArray();

            Serv.Update(category);
            return Ok(category);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete (int Id)
        {
         var category = await Serv.Getbyid(Id);

         Serv.Delete(category);

          return Ok(category);
        }


        


    }
}
