using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models.Product
{
    public class ProductCreateViewModel
    {
       
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        //public List<Shop> Shops { get; set; }
        //public List<OrderDetail> Orders { get; set; }

        //lazyloading virtual
    
    
        public List<SelectListItem> CategoryListItem { get; set; }
        
        public ICollection<global::Models.Product> ProductList { get; set; }
        public string ImageName { get; set; }

        [Display(Name = "Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
