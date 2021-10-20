using Models;
using Models.ViewModels;
using Models.ViewModels.OrderEditModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contracts
{
   public interface IOrderRepository:IRepository<Order>
    {
        public ICollection<vwOrderInfo> GetAllOrdersummary();
        //ICollection<SpOrderInfo> GetSpOrderInfo();
        //ICollection<SpOrderInfoParamater> GetSpOrderInfos_paramater(string OrderNo, string CustomerName);
        ICollection<spOrderID> GetSpOrderID(int id);
        ICollection<spOrderIDWiseDetails> GetSpOrderIDWiseDetails(int id);
        ICollection<OrderDetail> GetByOrderDetailsByID(int OrderDetailsID);
    }
}
