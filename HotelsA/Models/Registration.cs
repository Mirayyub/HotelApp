using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelsA.Models
{
    public class Registration
    {
        public int Id { get; set; }

        [Display(Name = "Qeydiyyat tarixi")]
        [Required(ErrorMessage = "Qeydiyyata alınma tarixini qeyd edin")]
        public DateTime CheckedIn { get; set; }

        [Display(Name = "Qeydiyyat bitmə tarixi")]
        [Required(ErrorMessage = "Qeydiyyatın bitmə tarixi qeyd edin")]
        public DateTime CheckedOut { get; set; }

        [Display(Name = "Otaq nömrəsi")]
        [Required(ErrorMessage = "Otaq nömrəsini qeyd edin")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        [Required(ErrorMessage = "Müştərini qeyd edin")]

        [Display(Name = "Müştəri")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? RestourantMenuId { get; set; }

        public RestourantMenu RestourantMenu { get; set; }

    }
}