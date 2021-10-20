using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models.Order;
using WebApplication6.Models.Order.OrderEditViewModel;
using WebApplication6.Models.Product;

namespace WebApplication6.AutomapperConfiguration
{
    public class AutomapperProfile:Profile
    {
      public AutomapperProfile()
        {
            CreateMap<ProductCreateViewModel, Product>();
            CreateMap<Product, ProductCreateViewModel>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

            CreateMap<ProductEditViewModel, Product>();
            CreateMap<Product, ProductEditViewModel>();
            

            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderViewModel, Order>();

            CreateMap<EditOrderModel, Order>();
            CreateMap<Order, EditOrderModel>();

            CreateMap<OrderDetail, EditOrderModel>();
            CreateMap<EditOrderModel, OrderDetail>();
        }
    }
}
