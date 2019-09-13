using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelsA.Models
{
    public class Food
    {
        public int Id { get; set; }

        [Display(Name = "Qida")]
        [Required(ErrorMessage = "Qidanı daxil edin")]
        [MaxLength(50, ErrorMessage = "Qida maximum 50 xarakter olmalıdır")]
        [MinLength(2, ErrorMessage = "Qida minumum 2 xarakter olmalıdır")]
        public string Name { get; set; }



        [Display(Name = "Qiymət")]
        [Required(ErrorMessage = "Qiyməti daxil edin")]
        [MaxLength(50, ErrorMessage = "Qiymət maximum 50 xarakter olmalıdır")]
        [MinLength(1, ErrorMessage = "Qiymət minumum 1 xarakter olmalıdır")]
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }



        [Display(Name = "Status")]
        public bool? IsDelete { get; set; }




        [Display(Name = "Kateqoriya")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}