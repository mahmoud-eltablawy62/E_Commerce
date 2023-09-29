using ECommerce.Models;

namespace ECommerce.Services

{
    public interface IProductServ
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetAllProductsbyCategory_Id(int id);
        Task<IEnumerable<Product>> GetAllbySearchItem(string SearchItem);
        Product Update(Product product);
        Product Delete(Product product);    
    }
}
