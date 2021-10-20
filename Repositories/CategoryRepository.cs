using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Base;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class CategoryRepository :Repository<Category>, ICategoryRepository
    {
        CustomerDbContext db = new CustomerDbContext();
        //public Category GetById(int id)
        //{
        //    //Customer customer = db.Customers.Find(id);
        //    Category product = db.Categorys.FirstOrDefault(c => c.Id == id);
        //    return product;
        //}
        //public bool Add(Category category)
        //{
        //    db.Categorys.Add(category);
        //    return db.SaveChanges() > 0;

        //}
        //public bool Update(Category category)
        //{
        //    db.Entry(category).State = EntityState.Modified;
        //    return db.SaveChanges() > 0;


        //}

        public override ICollection<Category> GetAll()
        {
           // this lazy loding 
           // return db.Categorys.ToList();

            //this is eager loading
          //  return db.Categorys.Include(c=>c.Products).ToList();

            //this is Explicit Loading
         var Categoris=db.Categorys.ToList();            
            return Categoris;
        }

        public List<Category> LoadProducts(List<Category> Categoris)
        {
            foreach (var category in Categoris)
            {
                db.Entry(category)
                    .Collection(c => c.Products)
                    .Query()
                    .Where(c=>c.IsActive==true)
                    .Load();
            }
            return Categoris;
        }

        //public List<Customer> GetShopId(int shopId, string ContactNo)
        //{
        //    List<Customer> customers = db.Customers.Where(c => c.ShopId == shopId)
        //        .Where(c => c.ContactNo == ContactNo)
        //        .ToList();
        //    return customers;
        //}
        //public bool Removed(int Id)
        //{
        //   Category category = GetById(Id);
        //    db.Categorys.Remove(category);
        //    return db.SaveChanges() > 0;
        //}
    }
}
