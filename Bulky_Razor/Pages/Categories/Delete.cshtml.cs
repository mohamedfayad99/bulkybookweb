using Bulky_Razor.Data;
using Bulky_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bulky_Razor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _db;
     
        public Category? category { get; set; }
        public DeleteModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                //category = _db.Categories.Find(id);
                category = _db.Categories.FirstOrDefault(u => u.Id == id);
            }

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                TempData["success"] = "Categorey Deleted Successfully";
                return RedirectToPage("Index");
            }
          
            return Page();
        }
    }
}
