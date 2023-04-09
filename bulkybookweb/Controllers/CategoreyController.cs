using bulkybookweb.Data;
using bulkybookweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace bulkybookweb.Controllers
{
    public class CategoreyController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CategoreyController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> res = _db.Categories;
            return View(res);
        }
        #region Create
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create(Category ct)
        {
            if (ct.Displayorder.ToString() == ct.name)
            {
                ModelState.AddModelError("name", "Displayorder cannot exactly of name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(ct);
                _db.SaveChanges();
                TempData["success"] = "Categorey Added Successfully";
                return RedirectToAction("Index");
            }
            return View(ct);
        }
        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catecoreyobject = _db.Categories.Find(id);
            if (catecoreyobject == null)
            {
                return NotFound();
            }
            return View(catecoreyobject);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(Category ct)
        {
            if (ct.Displayorder.ToString() == ct.name)
            {
                ModelState.AddModelError("name", "Displayorder cannot exactly of name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(ct);
                _db.SaveChanges();
                TempData["success"] = "Categorey Updated Successfully";
                return RedirectToAction("Index");

            }
            return View(ct);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catecoreyobject = _db.Categories.Find(id);
            if (catecoreyobject == null)
            {
                return NotFound();
            }
            return View(catecoreyobject);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var catecoreyobject = _db.Categories.Find(id);
            if (catecoreyobject == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(catecoreyobject);
            _db.SaveChanges();
            TempData["success"] = "Categorey Deleted Successfully";
            return RedirectToAction("Index");
        }
        #endregion

    }
}
