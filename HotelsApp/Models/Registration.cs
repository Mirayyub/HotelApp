using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelsApp.Models
{
    public class Registration
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Qeydiyyat tarixini qeyd edin")]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "Qeydiyyatın bitmə tarixi qeyd edin")]
        public DateTime End { get; set; }
        public DateTime Closed { get; set; }
        public DateTime Create { get; set; }

        [Required(ErrorMessage = "Otaq nömrəsini qeyd edin")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        [Required(ErrorMessage = "Müştərini qeyd edin")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}