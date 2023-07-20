using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }

        [Required]
        [Display(Name ="List Price")]
        [Range(1,1000)]
        public Decimal Listprice { get; set; }


        [Required]
        [Display(Name = "Price for 1:50")]
        [Range(1, 1000)]
        public Decimal List1 { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public Decimal List50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public Decimal List100 { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
       //[ValidateNever]
        public string Imageurl { get; set; }

    }
}
