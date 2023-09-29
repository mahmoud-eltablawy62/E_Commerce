using ECommerce.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services
{
    public class A_Con : IA_Con
    {

        private readonly AppDbContext _Context;
        public A_Con(AppDbContext Context)
        {
            _Context = Context;
        }

        public async Task<Category> Addcategory(Category cat)
        {
            await _Context.AddAsync(cat);
            _Context.SaveChanges();
            return cat;
        }

         public async Task<Product> Addproduct(Product product)
        {
            await _Context.AddAsync(product);
            _Context.SaveChanges();
            return product; 
        }

        public async Task<Category> Getbyid(int id)
        {
            return await _Context.Categories.Where(C => C.Id == id).SingleOrDefaultAsync();
        }  

        Category IA_Con.Update(Category category)
        {
            _Context.SaveChanges();
            return category;
        }

        Category IA_Con.Delete(Category category)
        {
            _Context.Remove(category);
            _Context.SaveChanges();
            return category;    

        }

        public async Task<IEnumerable<Product>> GetAllbycat_id(int Id)
        {
            var products = await _Context.Products.Where(p => p.Cat_id == Id).ToListAsync();
            return products;
        }

    
    }
}
