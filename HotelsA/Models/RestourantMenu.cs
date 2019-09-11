using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelsA.Models
{
    public class RestourantMenu
    {
        public int Id { get; set; }


        [Display(Name = "Məhsulun adı")]
        public string Name { get; set; }


        [Display(Name = "Qiymət")]
        public double? Price { get; set; }


        [Display(Name = "Məhsul haqqında")]
        [MinLength(3, ErrorMessage = "Məhsul haqqında minimum 3 xarakter olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Məhsul haqqında maximum 50 xarakter olmalıdır.")]
        public string Desc { get; set; }


        public List<Registration> Registrations { get; set; }


    }
}