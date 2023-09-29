using ECommerce.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace ECommerce.Services
{
    public interface IA_Con
    {
        Task<Category> Addcategory(Category cat);
        Task <Product> Addproduct(Product product);    
        Task <Category> Getbyid(int id); 
        Category Update (Category category);    
        Category Delete(Category category);
        Task <IEnumerable<Product>> GetAllbycat_id(int Id);
     
       
    }
}
