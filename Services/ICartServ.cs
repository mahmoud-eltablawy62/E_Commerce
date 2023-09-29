
using ECommerce.Models;
namespace ECommerce.Services
{
    public interface ICartServ
    {
        Task<IEnumerable<Cart>> GetAll();
        Task<Cart> Add(Cart cart);

     
    }
}
