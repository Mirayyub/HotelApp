using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelsA.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Kateqoriya")]
        [Required(ErrorMessage = "Kateqoriya daxil edin")]
        [MaxLength(500, ErrorMessage = "Kateqoriya maximum 50 xarakter olmalıdır")]
        [MinLength(2, ErrorMessage = "Kateqoriya minumum 2 xarakter olmalıdır")]
        public string CategoryName { get; set; }

        public List<Food> Foods { get; set; }
    }
}