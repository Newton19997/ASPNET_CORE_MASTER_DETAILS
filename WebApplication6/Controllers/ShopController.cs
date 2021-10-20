using BLL;
using BLL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Controllers
{
    public class ShopController : Controller
    {
        private IShopManager _shopManager;
        //public ShopController()
        //{
        //    IShopRepository shopRepository = new ShopRepository();
        //        _shopManager = new ShopManager(shopRepository);

        //}
        public ShopController(IShopManager shopManager)
        {
            _shopManager = shopManager;
        }
        // GET: ShopController
        public ActionResult Index()
        {
            var model = _shopManager.GetAll();
            return View(model);
        }

        // GET: ShopController/Details/5
        public ActionResult Details(int id)
        {

            var shopeditload = _shopManager.GetById(id);
            return View(shopeditload);
        }

        // GET: ShopController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shop shop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isAdded = _shopManager.Add(shop);
                    if (isAdded)
                    {

                        return RedirectToAction(nameof(Index));
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopController/Edit/5
        public ActionResult Edit(int id)
        {
            var shopeditload = _shopManager.GetById(id);

            return View(shopeditload);
        }

        // POST: ShopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Shop shop)
        {
            try
            {
                var edited = _shopManager.Update(shop);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopController/Delete/5
        public ActionResult Delete(int id)
        {
            var shopeditload = _shopManager.GetById(id);
            return View(shopeditload);
        }

        // POST: ShopController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Shop shop)
        {
            try
            {
                var deleted = _shopManager.Remove(shop);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
