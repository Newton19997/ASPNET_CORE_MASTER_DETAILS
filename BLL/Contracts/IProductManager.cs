using Models;
using Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Contracts
{
   public interface IProductManager: IManager<Product>
    {
        //bool Add(Product product);
        //bool Update(Product product);
        //bool Remove(Product product);
        ICollection<Product> GetByYear(int year);
        ICollection<Product> GetByCategory(int categoryId);
        ICollection<Product> ProductIDCategory(int productID);

        ICollection<spProductlist> GetspProductlist(int id);

        vwProductlist vwProductlist(int id);

    }
}
