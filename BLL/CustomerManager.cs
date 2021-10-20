using BLL.Base;
using BLL.Contracts;
using Models;
using Repositories;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class CustomerManager:Manager<Customer>,ICustomerManager
    {
        ICustomerRepository customerRepository;
        public CustomerManager(ICustomerRepository _customerRepository) :base(_customerRepository)
        {
            customerRepository = _customerRepository;
        }
      
    }
}
