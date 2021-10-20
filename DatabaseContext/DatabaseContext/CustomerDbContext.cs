using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Models.ViewModels;
using Models.ViewModels.OrderEditModel;
using Microsoft.Data.SqlClient;
using System.Data;
using Models.ProductViewModels;

namespace DatabaseContext
{
    public class CustomerDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Shop> Shops { get; set; }

        public DbQuery<vwOrderInfo> vwOrderInfos { get; set; }
        public DbQuery<vwProductlist> vwProductlists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);
            string connectionString = "Server=(local);Database=EcommerceDB1; Integrated Security=true";
            optionsBuilder.UseSqlServer(connectionString);

           //for lazy loding use
           // optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Query<vwOrderInfo>().ToView("vw_OrderInfo");
            modelBuilder.Query<vwProductlist>().ToView("vw_Productlist");

            //modelBuilder.Query<SpOrderInfo>();
            //modelBuilder.Query<SpOrderInfoParamater>();
            //for edit
            modelBuilder.Query<spOrderID>();
            modelBuilder.Query<spOrderIDWiseDetails>();

            modelBuilder.Query<spProductlist>();

        }

        // for edit 
        [Obsolete]
        public ICollection<spOrderID> GetSpOrderID(int id)
        {
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "OrderID";
            p1.DbType = DbType.Int32;
            p1.Value = id == null ? 0 : id;

            return this.Query<spOrderID>().FromSql("spOrderID @OrderID", p1).ToList();

        }
        [Obsolete]
        public ICollection<spOrderIDWiseDetails> GetSpOrderIDWiseDetails(int id)
        {
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "OrderID";
            p1.DbType = DbType.Int32;
            p1.Value = id == null ? 0 : id;

            return this.Query<spOrderIDWiseDetails>().FromSql("spOrderIDWiseDetails @OrderID", p1).ToList();
        }

        [Obsolete]
        public ICollection<spProductlist> GetspProductlist(int id)
        {
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "ProductID";
            p1.DbType = DbType.Int32;
            p1.Value = id == null ? 0 : id;

            return this.Query<spProductlist>().FromSql("spProductlist @Id", p1).ToList();
        }

    }

}
