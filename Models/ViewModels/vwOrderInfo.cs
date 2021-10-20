using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
   public class vwOrderInfo
    {
        public int id { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public double Totalprice { get; set; }
    }
}
