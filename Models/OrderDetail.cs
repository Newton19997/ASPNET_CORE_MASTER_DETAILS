using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class OrderDetail
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public double Qty { get; set; }

        public double UnitPrice { get; set; }
        public int DiscountPercentage { get; set; }
    }
}
