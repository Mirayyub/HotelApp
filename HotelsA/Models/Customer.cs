﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelsA.Models
{
    public class Customer
    {
        public int Id { get; set; }


        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Müştərinin ad və soyadını yazın.")]
        [MinLength(3, ErrorMessage = "ad və soyad minimum 3 xarakter olmalıdır.")]
        [MaxLength(50, ErrorMessage = "ad və soyad maximum 50 xarakter olmalıdır.")]
        public string Fullname { get; set; }



        [Display(Name = "Telefon nömrəsi")]
        [Required(ErrorMessage = "Müştərinin telefon nömrəsi yazın.")]
        [MinLength(6, ErrorMessage = "Telefon nömrəsi 6 rəqəmli olmalıdır.")]
        [MaxLength(15, ErrorMessage = "Telefon nömrəsi 15 rəqəmli olmalıdır.")]
        public string Phonenumber { get; set; }


        [Display(Name = "Pasport Seriyası")]
        [Required(ErrorMessage = "Pasport Seriyasını; yazın.")]
        [MinLength(6, ErrorMessage = "Pasport Seriyası 6 rəqəmli olmalıdır.")]
        [MaxLength(15, ErrorMessage = "Pasport Seriyası 15 rəqəmli olmalıdır.")]
        public string Passportcode { get; set; }
       

        public bool? IsDelete { get; set; }


        public List<Booking> Booking { get; set; }

    }
}