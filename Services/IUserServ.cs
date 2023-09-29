using ECommerce.Models;

namespace ECommerce.Services
{
    public interface IUserServ 
    {
        Task<IEnumerable<Cart>> GetCarts(int id);
        Task<Customer> GetCustomerById(int id);
        Customer Update(Customer customer);

    }
}
