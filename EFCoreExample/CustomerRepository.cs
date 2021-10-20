using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreExample
{
  public  class CustomerRepository
    {
        CustomerDbContext db = new CustomerDbContext();
        public Customer GetById(int id)
        {
            //Customer customer = db.Customers.Find(id);
            Customer customer = db.Customers.FirstOrDefault(c=>c.Id==id);
            return customer;
        }
        public bool Add(Customer customer)
        {
            db.Customers.Add(customer);
            return db.SaveChanges() > 0;

        }
        public bool Update(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            return db.SaveChanges() > 0;


        }

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }
        //public List<Customer> GetShopId(int shopId,string ContactNo)
        //{
        //    List<Customer> customers= db.Customers.Where(c=>c.ShopId== shopId)
        //        .Where(c=>c.ContactNo== ContactNo)
        //        .ToList();
        //    return customers;
        //}
        public bool Removed(int Id)
        {
            Customer customer = GetById(Id);
            db.Customers.Remove(customer);
            return db.SaveChanges() > 0;
        }

    }
}
