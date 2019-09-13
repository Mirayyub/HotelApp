using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelsA.Models
{
    public class BedType
    {
        public int Id { get; set; }

        [Display(Name = "Yataq növü")]
        [Required(ErrorMessage = "Yataq növünü daxil edin")]
        [MaxLength(500, ErrorMessage = "Yataq növünü maximum 50 xarakter olmalıdır")]
        [MinLength(2, ErrorMessage = "Yataq növünü minumum 2 xarakter olmalıdır")]
        public string TypeName { get; set; }

        public List<Room> Rooms { get; set; }
    }
}