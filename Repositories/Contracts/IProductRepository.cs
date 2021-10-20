using Models;
using Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contracts
{
   public interface IProductRepository:IRepository<Product>
    {
        ICollection<Product> GetByCategory(int categoryId);
        ICollection<Product> ProductIDCategory(int productID);
        ICollection<spProductlist> GetspProductlist(int productID);
        vwProductlist vwProductlist(int id);
    }
}
