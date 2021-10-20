using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]    
        public string CustomerName { get; set; }
        public string Address { get; set; }
       // public int ShopId { get; set; }
        public string ContactNo { get; set; }
        public List<Order> Orders { get; set; }
    }
}
