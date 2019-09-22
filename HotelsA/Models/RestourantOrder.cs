using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelsA.Models
{
    public class RestourantOrder
    {
        public int Id { get; set; }


        [Display(Name = "Məhsul")]
        [Required(ErrorMessage = "Məhsulu daxil edin")]
        
        public int FoodId { get; set; }
     
        public Food Food { get; set; }
        [Display(Name = "Məhsul sayı")]
        [Required(ErrorMessage = "Qidanı daxil edin")]
       
        public int FoodCount { get; set; }
        

        public bool? IsDelete { get; set; }

        [Display(Name = "Restorandakı sifarişlərin məbləği")]
        [Required]
        [Column(TypeName = "money")]
        public decimal FoodTotalPrice { get; set; }
        [Display(Name = "Otaq")]
        [Required(ErrorMessage = "Otaq daxil edin")]
        
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}