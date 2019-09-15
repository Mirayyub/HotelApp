using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelsA.Models
{
    public class BookingDetail
    {
        public int Id { get; set; }


        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }


        public bool? IsDeleted { get; set; }


        public int BookingId { get; set; }

        public Booking Booking { get; set; }


        public int RoomId { get; set; }


        public Room Room { get; set; }
    }
}