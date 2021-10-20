using BLL.Base;
using BLL.Contracts;
using Models;
using Models.ProductViewModels;
using Repositories;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class ProductManager:Manager<Product>,IProductManager
    {
        private IProductRepository _productRepository;
      public ProductManager(IProductRepository repository) :base(repository) 
        {
            _productRepository = repository;
        }

        public ICollection<Product> GetByYear(int year)
        {
            throw new NotImplementedException();
        }
        public ICollection<Product> GetByCategory(int categoryId)
        {
          var products= _productRepository.GetByCategory(categoryId);
            return products;
        }


        public ICollection<Product> ProductIDCategory(int productID)
        {
            var products = _productRepository.ProductIDCategory(productID);
            return products;
        }

        public ICollection<spProductlist> GetspProductlist(int productID)
        {
            var products = _productRepository.GetspProductlist(productID);
            return products;
        }

        public vwProductlist vwProductlist(int id)
        {
            var products = _productRepository.vwProductlist(id);
            return products;
        }
    }
}
