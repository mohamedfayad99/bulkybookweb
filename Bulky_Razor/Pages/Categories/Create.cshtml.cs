using Bulky_Razor.Data;
using Bulky_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bulky_Razor.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _db;
     
        public Category Category { get; set; }
        public CreateModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
           
        }
        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Categorey Added Successfully";
            return RedirectToPage("Index");
        }
    }
}
