using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ECommerce.Services
{
    public class CartServ : ICartServ
    {
        private readonly AppDbContext _Context;
        public CartServ(AppDbContext Context)
        {
            _Context = Context;
        }

        public async Task<Cart> Add(Cart cart)
        {
             _Context.Add(cart);
            _Context.SaveChanges();
            return cart;
        }

        public async Task<IEnumerable<Cart>> GetAll() =>
            await _Context.Carts.ToListAsync();

      
    }
}
