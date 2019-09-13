using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelsA.Models
{
    public class UserRol
    {
        public int Id { get; set; }

        [Display(Name = "Vəzifə")]
        [Required(ErrorMessage = "Vəzifəni daxil edin")]
        [MaxLength(500, ErrorMessage = "Vəzifəni maximum 50 xarakter olmalıdır")]
        [MinLength(2, ErrorMessage = "Vəzifəni minumum 2 xarakter olmalıdır")]
        public string UserType{get; set;}
        public List<User> Users { get; set; }
    }
}