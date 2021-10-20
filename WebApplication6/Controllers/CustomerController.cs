using BLL;
using BLL.Contracts;
using DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerManager _customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        public IActionResult Create()
        {
            //SelectListItem item = new SelectListItem();
           List<SelectListItem> addressDataList = new List<SelectListItem>() 
           { 
            new SelectListItem(){Value="DHA",Text="Dhaka"},
            new SelectListItem(){Value="CTG",Text="Chittagong"},
            new SelectListItem(){Value="SYL",Text="Sylhet"},
            new SelectListItem(){Value="BAR",Text="Barishal"},
            new SelectListItem(){Value="IND",Text="India"},

           };

            ViewBag.AddressList = addressDataList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {

                bool isSaved = _customerManager.Add(customer);
               
                if (isSaved)
                {
                    return RedirectToAction("Details", customer);
                }
                else
                {

                }
               // return View("Details", customer);
               // return RedirectToAction("Details", customer);
            }
            return View();
        }

        public IActionResult Details(Customer customer)
        {
            return View(customer);
        }
    }
}
