using AutoMapper;
using BLL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models.Order;
using WebApplication6.Models.Order.OrderEditViewModel;

namespace WebApplication6.Controllers
{
    public class OrderController : Controller
    {
        private IProductManager productManager;
        private IOrderManager orderManager;
        private IMapper mapper;
        private ICustomerManager customerManager;
       private IOrderdetailsManager orderdetailsManager;
        public OrderController(IProductManager _productManager,  IMapper _mapper, IOrderManager _orderManager, ICustomerManager _customerManager, IOrderdetailsManager _orderdetailsManager) //
        {
            productManager = _productManager;
           orderManager = _orderManager;
            mapper = _mapper;
           customerManager = _customerManager;
           orderdetailsManager = _orderdetailsManager;
        }
        // GET: OrderController
        public ActionResult Index()
        {
            var model = orderManager.GetAllOrdersummary();
            return View(model);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            var productList = productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            var model = new OrderViewModel()
            {
                ProductSelectItem = productList
            };


            var customerlist = customerManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.CustomerName
            }).ToList();
            model.Customers = customerlist;

            return View(model);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = mapper.Map<Order>(model);
                bool isAdded = orderManager.Add(order);
                if (isAdded)
                {
                   // return RedirectToAction(nameof(Index), "Home");
                    return RedirectToAction(nameof(Index));
                }

            }

            var productList = productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            model.ProductSelectItem = productList;

            var customerlist = customerManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.CustomerName
            }).ToList();
            model.Customers = customerlist;

            return View(model);
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new EditOrderModel();
            var productList = productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            ViewBag.productList = productList;
            model.ProductSelectItem = productList;

            var customerlist = customerManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.CustomerName
            }).ToList();
            model.Customers = customerlist;

            var OrderId = orderManager.GetSpOrderID(id).ToList();
            model.id = OrderId[0].id;
            model.OrderNo = OrderId[0].OrderNo;
            model.OrderDate = OrderId[0].OrderDate;
            model.CustomerId = OrderId[0].CustomerId;

            var OrderIDWiseDetail = orderManager.GetSpOrderIDWiseDetails(id).ToList();
            model.OrderDetails = OrderIDWiseDetail.ToList();

            return View(model);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditOrder(int id, EditOrderModel model)
        {
            try
            {
                var order = mapper.Map<Order>(model);
                var edited = orderManager.Update(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        [Route("api/Order/OrderDetails")]
        public IEnumerable<OrderDetail> GetByOrderDetailsByID(int Id)
        {
            var OrderDetailIDWise = orderManager.GetByOrderDetailsByID(Id).ToList();
            return OrderDetailIDWise;
        }
        [Route("api/Order/OrderDetails")]
        [HttpPost]
        public IActionResult PostOrderDetails(EditOrderModel model)
        {
            if (ModelState.IsValid)
            {
                OrderDetail orderDetail = new OrderDetail();
                //orderDetail.Id = model.Id;
                orderDetail.OrderId = model.id;
                orderDetail.ProductId = model.ProductId;
                orderDetail.Qty = model.Qty;
                orderDetail.UnitPrice = model.UnitPrice;
                orderDetail.DiscountPercentage = model.DiscountPercentage;



                var IsAdded = orderdetailsManager.Add(orderDetail);
                if (IsAdded)
                {
                    return Ok(orderDetail);
                    //return RedirectToAction(nameof(Index));
                    //return Ok(product);
                }
            }
            return Ok();
        }

        [Route("api/Order/editOrderDetails")]
        [HttpPost]
        public IActionResult EditOrderDetails(EditOrderModel model)
        {
            if (ModelState.IsValid)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.Id = model.Id;
                orderDetail.OrderId = model.OrderId;
                orderDetail.ProductId = model.ProductId;
                orderDetail.Qty = model.Qty;
                orderDetail.UnitPrice = model.UnitPrice;
                orderDetail.DiscountPercentage = model.DiscountPercentage;


                var IsAdded = orderdetailsManager.Update(orderDetail);
                //return RedirectToAction(nameof(Index));
                //var IsAdded = orderdetailsManager.Add(orderDetail);
                if (IsAdded)
                {
                    //return RedirectToAction(nameof(Index));
                    return Ok(orderDetail);
                    //return Ok(product);
                }
            }
            return Ok();
        }
    }
}
