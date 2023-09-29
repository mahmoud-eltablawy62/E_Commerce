using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ECommerce.Services
{
    public class ProductServ : IProductServ
    {
        private readonly AppDbContext _Context;
        public ProductServ(AppDbContext Context)
        {
            _Context = Context;
        }

        public async Task<IEnumerable<Product>> GetAllProduct() =>
            await _Context.Products.ToListAsync();

        public async Task<IEnumerable<Product>> GetAllbySearchItem(string SearchItem)
        {
            IQueryable<Product> quary = _Context.Products;
            if(quary != null) { 
            quary = quary.Where(item=>item.Name.Contains(SearchItem));    
            }            
            return await quary.ToListAsync();         
        }
        public async Task<IEnumerable<Product>> GetAllProductsbyCategory_Id(int id) =>
            await _Context.Products.Where(C => C.Cat_id == id).ToListAsync();

        public async Task<Product> GetProductById(int id) =>
            await _Context.Products.Where(B => B.Id == id).FirstOrDefaultAsync();

        Product IProductServ.Update(Product product)
        {
            _Context.SaveChanges();
            return product;
        }

        Product IProductServ.Delete(Product product)
        {
            _Context.Remove(product);   
            _Context.SaveChanges();
            return product; 
        }
    }
}
