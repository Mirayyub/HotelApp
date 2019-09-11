﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelsA.Models
{
    public class Room
    {
        public enum BedType
        {
            Tək, Cüt
        }
        

            public int Id { get; set; }

            [Required(ErrorMessage = "Otaq nömrəsini yazın.")]
            [Range(1, 500, ErrorMessage = "Otaq nömrəsi 500-dən yuxarı ola bilməz")]

            public int Number { get; set; }

            [Required(ErrorMessage = "Otağın qiymətini yazın.")]
            [Range(50, 1000, ErrorMessage = "Otağın bir gecəsi 50 manatdan aşağı, 1000 manatdan yuxarı ola bilməz")]
            public double Price { get; set; }

            [Required(ErrorMessage = "Otağın statusunu qeyd edin.")]
            public bool Status { get; set; }


            [Required(ErrorMessage = "Çarpayının növünü seçin.")]
            public BedType Type { get; set; }

            [Required(ErrorMessage = "Otağın böyüklər üçün tutumunu yazın.")]
            [Range(1, 4, ErrorMessage = "4 nəfərdən artıq tutumu olan otaq yoxdur.")]

            public int PersonCapacity { get; set; }

            [Required(ErrorMessage = "Otağın uşaqlar üçün tutumunu yazın.")]
            [Range(1, 5, ErrorMessage = "5 nəfər uşaqdan artıq tutumu olan otaq yoxdur.")]
            public int ChildCapacity { get; set; }


            [Required(ErrorMessage = "Otaq haqqında məlumatları yazın.")]
            [MaxLength(500, ErrorMessage = "Otaq haqqında məlumatları yazın.")]
            public string Desc { get; set; }

            public List<Registration> Registrations { get; set; }
        }
}