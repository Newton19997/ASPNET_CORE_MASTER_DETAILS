using AutoMapper;
using BLL;
using BLL.Base;
using BLL.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models.Product;
using static System.Net.WebRequestMethods;

namespace WebApplication6.Controllers
{
    public class ProductController : Controller
    {
        private IProductManager _productManager;
        private ICategoryManager _categoryManager;

        private readonly IMapper _mapper;
        private IWebHostEnvironment _webhostenverment;
        //private object file;
        public ProductController(IWebHostEnvironment webhostenverment,IProductManager ProductManager , ICategoryManager categoryManager, IMapper mapper)
        {
            _productManager = ProductManager;
            _categoryManager = categoryManager;
            _mapper = mapper;
            _webhostenverment = webhostenverment;
        }
        // GET: ProductController
        public ActionResult Index()
        {

            var products = _productManager.GetAll();
            var productViewmodelList = _mapper.Map<IEnumerable<ProductViewModel>>(products);
            return View(productViewmodelList);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var productLoad = _productManager.GetById(id);
            //var pro = _productManager.vwProductlist(id);
            //vwProductlist pro = new vwProductlist();
           // var productLoad = _productManager.ProductIDCategory(id);
            var productViewmodelListn = _mapper.Map<ProductViewModel>(productLoad);
            
            return View(productViewmodelListn);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            List<SelectListItem> categoryitem = _categoryManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            //ViewBag.CategoryItemList = categoryitem;

            var model = new ProductCreateViewModel();
           model.CategoryListItem = categoryitem;
            model.ProductList = _productManager.GetAll();
            return View(model);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //save image to wwwRoot/UploadImages
                    string wwwRootPath = _webhostenverment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string extension =Path.GetExtension(model.ImageFile.FileName);
                    model.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/UploadImages", fileName);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        model.ImageFile.CopyToAsync(filestream);
                    }
                        //end imagesave
                        //var product = new Product()
                        //{
                        //    Name = model.Name,
                        //    CategoryId = model.CategoryId,
                        //    Description = model.Description,
                        //};
                        //Same work there are
                        var product = _mapper.Map<Product>(model);

                    bool isAdded = _productManager.Add(product);
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {

            List<SelectListItem> categoryitem = _categoryManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            //ViewBag.CategoryItemList = categoryitem;

            var model = new ProductEditViewModel();
            model.CategoryListItem = categoryitem;
            //  model.ProductList = _productManager.GetAll();

            var productLoad = _productManager.GetById(id);
            model.Id = productLoad.Id;
            model.Name = productLoad.Name;
            model.Price = productLoad.Price;
            model.Description = productLoad.Description;
            model.IsActive = productLoad.IsActive;
            model.CategoryId = productLoad.CategoryId;
            model.ImageName = productLoad.ImageName;
           // model.ImageFile = productLoad.ImageName;

            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEditViewModel model)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    List<SelectListItem> categoryitem = _categoryManager.GetAll().Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList();

                    //ViewBag.CategoryItemList = categoryitem;

                    // var model = new ProductEditViewModel();
                    model.CategoryListItem = categoryitem;
                   

                    if (model.ImageFile != null)
                    {
                        //string filename = System.Guid.NewGuid().ToString() + ".Jpg";
                        //string path1 = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "UploadImages", filename);
                        //using (var stream = new FileStream(path1, FileMode.Create))
                        //{
                        //    model.ImageFile.CopyToAsync(stream);
                        //}
                        //model.ImageName = filename;

                        ////save image to wwwRoot/ UploadImages bewton
                        string wwwRootPath = _webhostenverment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                        string extension = Path.GetExtension(model.ImageFile.FileName);
                        model.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath + "/UploadImages", fileName);
                        using (var filestream = new FileStream(path, FileMode.Create))
                        {
                            model.ImageFile.CopyToAsync(filestream);
                        }

                        var product = _mapper.Map<Product>(model);
                        //Product product = new Product();
                        //product.Id = model.Id;
                        //product.CategoryId = model.CategoryId;
                        //product.Description = model.Description;
                        //product.ImageName = model.ImageName;
                        //product.IsActive = model.IsActive;
                        //product.Name = model.Name;
                        //product.Price = model.Price;

                        bool edited = _productManager.Update(product);
                        if (edited)
                        {
                            //Delete image from wwwroot/image
                            //var productLoad = _productManager.GetById(id);
                            //var imagepath = Path.Combine(_webhostenverment.WebRootPath, "UploadImages", productLoad.ImageName);
                            //if (System.IO.File.Exists(imagepath))
                            //    System.IO.File.Delete(imagepath);
                            //Delete image from wwwroot/imageend newton
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        var product = _mapper.Map<Product>(model);
                        bool edited = _productManager.Update(product);
                        if (edited)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }



                    //var order = mapper.Map<Order>(model);
                    //var edited = orderManager.Update(order);
                    //return RedirectToAction(nameof(Index));
                    return RedirectToAction(nameof(Index));
                }

              
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var productLoad = _productManager.GetById(id);
            //var pro = _productManager.vwProductlist(id);
            //vwProductlist pro = new vwProductlist();
            // var productLoad = _productManager.ProductIDCategory(id);
            var productViewmodelListn = _mapper.Map<ProductViewModel>(productLoad);

            return View(productViewmodelListn);

      
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductViewModel model)
        {
            try
            {
                var productLoad = _productManager.GetById(id);
                //Delete image from wwwroot/image
                var imagepath = Path.Combine(_webhostenverment.WebRootPath, "UploadImages", productLoad.ImageName);
                if (System.IO.File.Exists(imagepath))
                    System.IO.File.Delete(imagepath);

             
                var product = _mapper.Map<Product>(productLoad);

                var deleted = _productManager.Remove(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CategoryWiseProduct()
        {
            var model = new CategoryWiseProductViewModel();
            model.CategoryList = _categoryManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
             if(model.CategoryList==null)
            {
                model.CategoryList = new List<SelectListItem>();
            }
            return View(model);
        }
        //[Route("api/[controller]/[action]")]
        //handcodeforuch OR
        [Route("api/Product/productlist")]
        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            var Products = _productManager.GetByCategory(categoryId);
            return Products;
        }
    }
}
