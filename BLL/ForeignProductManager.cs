using BLL.Base;
using BLL.Contracts;
using Models;
using Models.ProductViewModels;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
  public  class ForeignProductManager:Manager<Product>, IProductManager
    {
        public ForeignProductManager():base(new ProductRepository())
        {

        }
        public override bool Add(Product entity)
        {
            //foregin productadd policy
            if (true)
            {

            }else
            {

            }
            return base.Add(entity);
        }

        public ICollection<Product> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetByYear(int year)
        {
            throw new NotImplementedException();
        }

         public ICollection<Product> ProductIDCategory(int productID)
        {

            throw new NotImplementedException();
        }
        public ICollection<spProductlist> GetspProductlist(int productID)
        {
            throw new NotImplementedException();
        }

        public vwProductlist vwProductlist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
