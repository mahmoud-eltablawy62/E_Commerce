using ECommerce.Dtos;
using ECommerce.Models;
using ECommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly ICartServ Serv;
        private readonly IProductServ prodServ;
        
        public CartController(ICartServ _Serv , IProductServ _prodServ)
        {
            Serv = _Serv;   
            prodServ = _prodServ;   
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product = await Serv.GetAll();
            return Ok(product); 
        }

        [HttpPost]
        [Route("product/{prod_id}")]
        public async Task<IActionResult> Add(int prod_id, [FromForm] cartDto dto)
        {
            var prod = await prodServ.GetProductById(prod_id);
            decimal price = prod.Price;  
            decimal t_price = dto.Qnt * price;
            var carts = new Cart
            {
                product_id = prod_id,
                Qnt = dto.Qnt,
                Total_Price = t_price,
                customer_id = 2 , 
            };
             await Serv.Add(carts);
             return Ok();
        }

    }
}
