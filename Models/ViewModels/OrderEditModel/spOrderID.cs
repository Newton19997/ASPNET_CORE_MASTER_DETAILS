using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.OrderEditModel
{
   public class spOrderID
    {
        public int id { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
