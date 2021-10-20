using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ProductViewModels
{
    public class spProductlist
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public string ImageName { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
    }



}
