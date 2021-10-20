using Models;
using Models.ViewModels;
using Models.ViewModels.OrderEditModel;
using Repositories.Base;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
   public class OrderRepository : Repository<Order>, IOrderRepository
    {

        public ICollection<vwOrderInfo> GetAllOrdersummary()
        {
            return db.vwOrderInfos.ToList();
        }

        [Obsolete]
        public ICollection<spOrderID> GetSpOrderID(int id)
        {
            return db.GetSpOrderID(id);
        }

        [Obsolete]
        public ICollection<spOrderIDWiseDetails> GetSpOrderIDWiseDetails(int id)
        {
            return db.GetSpOrderIDWiseDetails(id);
        }
        public ICollection<OrderDetail> GetByOrderDetailsByID(int OrderDetailsID)
        {
            return db.OrderDetails.Where(m => m.Id == OrderDetailsID).ToList();
        }
    }
}
