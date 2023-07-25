using Bulky.DataAcces.Data;
using Bulky.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Bulkybookweb.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(ApplicationDBContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {                
            IEnumerable<Product> res = _db.Products;
            IEnumerable<Category> cat=_db.Categories.ToList();

                ViewData["Products"] = res;
                ViewData["Categories"] = cat;

            return View();
        }
        #region Upsert
        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> categoryproduct = _db.Categories
                 .Select(s => new SelectListItem
                 {
                     Text = s.name,
                     Value = s.Id.ToString()
                 });
            if (id == null || id == 0)
            {
                //create
                // ViewBag.categoryproduct = categoryproduct;
                ViewData["categoryproduct"] = categoryproduct;
                return View();
            }
            else 
            {
                //update
                ViewData["categoryproduct"] = categoryproduct;
                Product  product= _db.Products.SingleOrDefault(u=>u.Id==id);
                //ViewData["product"] = product;
                return View(product);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert([FromForm]Product product,IFormFile? file )
        {
            if (ModelState.IsValid)
            {
                string WWWRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(WWWRootPath, @"images\product");
                    if (!string.IsNullOrEmpty(product.Imageurl))
                    {
                        //delete old image
                        var oldimage = Path.Combine(WWWRootPath, product.Imageurl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldimage))
                        {
                            System.IO.File.Delete(oldimage);
                        }
                    }
                    using (var filestream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    product.Imageurl = @"\images\product\" + filename;
                }
                if (product.Id == 0)
                {
                    _db.Products.Add(product);
                }
                else
                {
                    _db.Products.Update(product);
                }
                _db.SaveChanges();
                TempData["success"] = "product Added Successfully";
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        #endregion

        #region Edit
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var catecoreyobject = _db.Products.Find(id);
        //    if (catecoreyobject == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(catecoreyobject);
        //}

        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditPost(Product product)
        //{


        //    if (ModelState.IsValid)
        //    {
        //        _db.Products.Update(product);
        //        _db.SaveChanges();
        //        TempData["success"] = "product Updated Successfully";
        //        return RedirectToAction("Index");

        //    }
        //    return View(product);
        //}
        #endregion

        #region Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productobject = _db.Products.Find(id);
            Category cccc = _db.Categories.SingleOrDefault(s => s.Id == productobject.CategoryId);
            ViewData["cccc"] = cccc.name;
            if (productobject == null)
            {
                return NotFound();
            }
            return View(productobject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productobject = _db.Products.Find(id);

            if (productobject == null)
            {
                return NotFound();
            }
            _db.Products.Remove(productobject);
            _db.SaveChanges();
            TempData["success"] = "productobject Deleted Successfully";
            return RedirectToAction("Index");

        }
        #endregion

        #region Api

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Product> res = _db.Products;
            IEnumerable<Category> cat = _db.Categories.ToList();

            ViewData["Products"] = res;
            ViewData["Categories"] = cat;
            return Json(new { data = res });
        }
        #endregion


    }
}
