using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services
{
    public class CategoryServ : ICategoryServ
    {
        private readonly AppDbContext _Context;
        public CategoryServ(AppDbContext Context)
        {
            _Context = Context; 
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
           return await _Context.Categories.ToListAsync();  
        }

    }
}
