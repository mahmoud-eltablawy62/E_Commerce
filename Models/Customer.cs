using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }

        public string? Phone { get; set; }
        public string? Passworded { get; set; }

        public string? Confirm_Password { get; set; }


        public decimal  ? total_price { get; set; }

        [ForeignKey("Cart")]
        public int cart_id { get; set; }    
        public Cart Cart { get; set; }  

    }
}
