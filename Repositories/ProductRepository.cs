using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ProductViewModels;
using Repositories.Base;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
   public class ProductRepository:Repository<Product>, IProductRepository
    {

         public override ICollection<Product> GetAll()
        {
           // this lazy loding 
           // return db.Categorys.ToList();

            //this is eager loading
           return db.Products.Include(c=>c.Category).ToList();

            //this is Explicit Loading
         //var Categoris=db.Categorys.ToList();            
         //   return Categoris;
        }
        //CustomerDbContext db = new CustomerDbContext();
        //public Product GetById(int id)
        //{
        //    //Customer customer = db.Customers.Find(id);
        //    Product product = db.Products.FirstOrDefault(c => c.Id == id);
        //    return product;
        //}
        //public bool Add(Product product)
        //{
        //    db.Products.Add(product);
        //    return db.SaveChanges() > 0;

        //}
        //public bool Update(Product product)
        //{
        //    db.Entry(product).State = EntityState.Modified;
        //    return db.SaveChanges() > 0;


        //}

        //public List<Product> GetAll()
        //{
        //    return db.Products.ToList();
        //}
        ////public List<Customer> GetShopId(int shopId, string ContactNo)
        ////{
        ////    List<Customer> customers = db.Customers.Where(c => c.ShopId == shopId)
        ////        .Where(c => c.ContactNo == ContactNo)
        ////        .ToList();
        ////    return customers;
        ////}
        //public bool Removed(int Id)
        //{
        //    Product product = GetById(Id);
        //    db.Products.Remove(product);
        //    return db.SaveChanges() > 0;
        //}

        public ICollection<Product> ProductIDCategory(int productID)
        {

            //var stud1 = ctx.Students
            //       .Include("Standard")
            //       .Where(s => s.StudentName == "Bill")
            //       .FirstOrDefault<Student>();

            return db.Products.Include(c => c.Category)
                .Where(c => c.Id == productID).ToList();
            //return db.Products.Where(c => c.CategoryId == categoryId).ToList();

            //var stud1 = ctx.Students.Include(s => s.Standard.Teachers)
            //        .Where(s => s.StudentName == "Bill")
            //        .FirstOrDefault<Student>();
        }

        public ICollection<spProductlist> GetspProductlist(int productID)
        {
            return db.GetspProductlist(productID);
        }

        public vwProductlist vwProductlist(int id)
        {
            vwProductlist product = db.vwProductlists.Find(id);
            return product;
        }

        public ICollection<Product> GetByCategory(int categoryId)
        {
          return  db.Products.Where(c => c.CategoryId == categoryId).ToList();
        }
    }
}
