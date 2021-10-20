using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.OrderEditModel
{
   public class spOrderIDWiseDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }
        public int DiscountPercentage { get; set; }
    }
}
