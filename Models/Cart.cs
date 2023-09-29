using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal Total_Price { get; set; }    
        public int Qnt { get; set; }

        [ForeignKey("Product")]
        public int product_id { get; set; } 
        public Product Product { get; set; }

        [ForeignKey("customer")]
        public int customer_id { get; set;}
        public Customer customer { get; set; }    
   
    }
}
