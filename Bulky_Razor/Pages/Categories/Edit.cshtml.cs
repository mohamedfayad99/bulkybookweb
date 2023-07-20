using Bulky_Razor.Data;
using Bulky_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bulky_Razor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public Category? category { get; set; }
        public EditModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            if(id !=null && id != 0)
            {
                //category = _db.Categories.Find(id);
                  category = _db.Categories.FirstOrDefault(u => u.Id == id);
            }

        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _db.Categories.Update(category);
            _db.SaveChanges();
            TempData["success"] = "Categorey Updated Successfully";
            return RedirectToPage("Index");
        }
    }
}
