using System.ComponentModel.DataAnnotations;

namespace Bulky_Razor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }

        [Range(1, 100, ErrorMessage = "Display Order must only between 1 and 100  !!")]
        public int Displayorder { get; set; }
        public DateTime dt { get; set; } = DateTime.Now;
    }
}
