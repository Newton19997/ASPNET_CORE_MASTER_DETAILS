using BLL.Base;
using BLL.Contracts;
using Models;
using Models.ViewModels;
using Models.ViewModels.OrderEditModel;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class OrderManager : Manager<Order>, IOrderManager
    {
        private IOrderRepository _repository;
        public OrderManager(IOrderRepository orderRepository) : base(orderRepository)
        {
            _repository = orderRepository;
        }
        public ICollection<vwOrderInfo> GetAllOrdersummary()
        {
            return _repository.GetAllOrdersummary();
        }

        //for edit
        public ICollection<spOrderID> GetSpOrderID(int id)
        {
            return _repository.GetSpOrderID(id);
        }

        public ICollection<spOrderIDWiseDetails> GetSpOrderIDWiseDetails(int id)
        {
            return _repository.GetSpOrderIDWiseDetails(id);
        }

        public ICollection<OrderDetail> GetByOrderDetailsByID(int OrderDetailsID)
        {
            return _repository.GetByOrderDetailsByID(OrderDetailsID);
        }
        //end  //for edit
    }
}
