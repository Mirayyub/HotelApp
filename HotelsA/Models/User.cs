﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelsA.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "İstifadəçinin ad və soyadını yazın.")]
        [MaxLength(30, ErrorMessage = "İstifadəçinin ad və soyadını maximum 30 xarakter olmalıdır")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "İstifadəçi adını yazın.")]
        [MaxLength(30, ErrorMessage = "İstifadəçi adı maximum 30 xarakter olmalıdır")]
        [Display(Name = "İstifadəçi adı")]
        public string UserName { get; set; }

        [Display(Name = "Şifrə")]
        [Required(ErrorMessage = "Şifrəni qeyd edin")]
        [MaxLength(60, ErrorMessage = "Şifrə maximum 60 xarakter olmalıdır.")]
        public string Password { get; set; }

        public List<UserRol> UserRols { get; set; }

    }
}