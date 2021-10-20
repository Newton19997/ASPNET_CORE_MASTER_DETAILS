using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Base
{
  public abstract class Repository<T>: IRepository<T> where T:class
    {
      protected CustomerDbContext db;

        public Repository()
        {
            db = new CustomerDbContext();
        }
        private DbSet<T> Table
        {
            get { return db.Set<T>(); }
        }
        public virtual bool Add(T entity)
        {
            Table.Add(entity);
            return db.SaveChanges() > 0;
        }

        public virtual bool Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public virtual bool Remove(T entity)
        {

            Table.Remove(entity);
            return db.SaveChanges() > 0;
        }

        public virtual T GetById(int id)
        {
            //Customer customer = db.Customers.Find(id);
            return Table.Find(id);
        
        }
        public virtual ICollection<T> GetAll()
        {
            return Table.ToList();
        }
    }
}
