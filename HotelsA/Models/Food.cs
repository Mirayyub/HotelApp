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

        [Display(Name = "Məhsul")]
        [Required(ErrorMessage = "Qidanı daxil edin")]
        [MaxLength(50, ErrorMessage = "Qida maximum 50 xarakter olmalıdır")]
        [MinLength(2, ErrorMessage = "Qida minumum 2 xarakter olmalıdır")]
        public string Name { get; set; }



        [Display(Name = "Qiymət")]
        [Required(ErrorMessage = "Qiyməti daxil edin")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }




        
        public bool? IsDelete { get; set; }




        [Display(Name = "Kateqoriya")]
        public int CategoryId { get; set; }
        [Display(Name = "Kateqoriya")]
        public Category Category { get; set; }

        public List<RestourantOrder> RestourantOrders { get; set; }
    }
}