using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services
{
    public class UserServ : IUserServ
    {
        private readonly AppDbContext _context;
        public UserServ(AppDbContext Context)
        {
            _context = Context;
        }

        public async Task<IEnumerable<Cart>> GetCarts(int id)
        {
           return await _context.Carts.Where(C=>C.customer_id == id).ToListAsync();
        }

         public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers.SingleAsync(c => c.Id == id);   
        }

      
        Customer IUserServ.Update(Customer customer)
        {
            _context.SaveChanges();
            return customer;
        }
    }
}
