using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int? CustomerId  { get; set; }
        public Customer Customer { get; set; }
        public string OrderNo { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        



    }
}
