using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelsA.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Display(Name = "Qeydiyyat tarixi")]
        [Required(ErrorMessage = "Qeydiyyata alınma tarixini qeyd edin")]
        public DateTime CheckedIn { get; set; }


        [Display(Name = "Qeydiyyatın bitmə tarixi")]
        [Required(ErrorMessage = "Qeydiyyatın bitmə tarixi qeyd edin")]
        public DateTime CheckedOut { get; set; }

        [Required(ErrorMessage = "Müştərini qeyd edin")]
        public int CustomerId { get; set; }

        [Display(Name = "Müştəri")]
        public Customer Customer { get; set; }



        public int UserId { get; set; }

        public User User { get; set; }

        public List<BookingDetail> BookingDetails { get; set; }
    }
}