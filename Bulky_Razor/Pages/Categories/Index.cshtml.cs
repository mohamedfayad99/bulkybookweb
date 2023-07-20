using Bulky_Razor.Data;
using Bulky_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bulky_Razor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public List<Category> Categories { get; set; }
        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Categories=_db.Categories.ToList();
        }
    }
}
