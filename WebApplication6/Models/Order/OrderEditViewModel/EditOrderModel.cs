using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels.OrderEditModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models.Order.OrderEditViewModel
{
    public class EditOrderModel
    {
        public int id { get; set; }
        public int OrderId { get; set; }

        [Display(Name = "Order No")]
        public string OrderNo { get; set; }

        [Display(Name = "Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }


        public List<spOrderIDWiseDetails> OrderDetails { get; set; }
        public List<SelectListItem> ProductSelectItem { get; set; }
        public List<SelectListItem> Customers { get; set; }

        [Display(Name = "Order Detail")]
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }
        public int DiscountPercentage { get; set; }
    }
}
