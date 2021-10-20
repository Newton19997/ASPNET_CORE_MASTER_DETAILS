using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models.Order
{
    public class OrderViewModel
    {
        [Display(Name = "Order No")]
        public string OrderNo { get; set; }
        [Display(Name = "Date")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public List<SelectListItem> ProductSelectItem { get; set; }
        public List<SelectListItem> Customers { get; set; }

    }
}
