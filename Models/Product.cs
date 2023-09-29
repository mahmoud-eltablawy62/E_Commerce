using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] ? Phote { get; set; }
        [ForeignKey("Category")]         
        public int? Cat_id { get; set; } 
        public Category? Category { get; set; }
       public List<Cart> Carts { get; set; }    
             
      }
}
