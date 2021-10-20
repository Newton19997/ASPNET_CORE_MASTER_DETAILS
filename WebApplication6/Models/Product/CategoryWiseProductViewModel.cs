using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models.Product
{
    public class CategoryWiseProductViewModel
    {
        public ICollection<SelectListItem> CategoryList { get; set; }
    }
}
