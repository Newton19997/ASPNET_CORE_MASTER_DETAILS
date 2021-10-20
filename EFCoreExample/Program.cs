using DatabaseContext;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreExample
{
    class Program
    {
        static void Main(string[] args)
        {
           
            CategoryRepository categoryRepository = new CategoryRepository();
           var cat= categoryRepository.GetAll();
            categoryRepository.LoadProducts(cat);

            if (cat != null && cat.Any())
            {
                foreach (var categoryProduct in cat)
                {
                    Console.WriteLine("category Name ;" + categoryProduct.Name+"Code:" + categoryProduct.Code);
                    if (categoryProduct.Products != null && categoryProduct.Products.Any())
                    {
                        foreach(var product in categoryProduct.Products)
                        {
                            Console.WriteLine("product Name ;" + product.Name + "price:" + product.Price);

                        }
                    }

                    }
            }

          // Console.WriteLine("PRODUCT Name ;" + product.Name);

            Console.ReadKey();
        }
    }
}
