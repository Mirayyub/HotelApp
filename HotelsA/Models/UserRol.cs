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
        public string UserType{get; set;}

        public int UserId { get; set; }
        public User User { get; set; }
    }
}