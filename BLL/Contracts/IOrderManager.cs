using Models;
using Models.ViewModels;
using Models.ViewModels.OrderEditModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Contracts
{
    public interface IOrderManager : IManager<Order>
    {
      public  ICollection<vwOrderInfo> GetAllOrdersummary();

        //for edit
        ICollection<spOrderID> GetSpOrderID(int id);
        ICollection<spOrderIDWiseDetails> GetSpOrderIDWiseDetails(int id);
        ICollection<OrderDetail> GetByOrderDetailsByID(int OrderDetailsID);
    }
}
