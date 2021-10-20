using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        
        //  lazyload virtual
        public  List<Product> Products { get; set; }
    }
}
