using ECommerce.Models;

namespace ECommerce.Services
{
    public interface ICategoryServ
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
