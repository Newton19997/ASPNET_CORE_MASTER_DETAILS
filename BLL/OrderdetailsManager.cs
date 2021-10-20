using BLL.Base;
using BLL.Contracts;
using Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class OrderdetailsManager : Manager<OrderDetail>, IOrderdetailsManager
    {
        IOrderdetailsRepository orderdetailsRepository;
        public OrderdetailsManager(IOrderdetailsRepository repository) : base(repository)
        {

            orderdetailsRepository = repository;
            //    customerRepository = new CustomerRepository();
        }
    }
}
