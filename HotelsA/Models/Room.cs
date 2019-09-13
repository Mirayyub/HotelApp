using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "Otaq")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Otağın qiymətini yazın.")]
        [Range(50, 1000, ErrorMessage = "Otağın bir gecəsi 50 manatdan aşağı, 1000 manatdan yuxarı ola bilməz")]
        [Display(Name = "Qiymət")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Otağın statusunu qeyd edin.")]
        [Display(Name = "Vəziyyəti")]
        public bool Status { get; set; }


        [Display(Name = "Çarpayı Növü")]
        [Required(ErrorMessage = "Çarpayının növünü seçin.")]
        public BedType Type { get; set; }


        [Required(ErrorMessage = "Otağın böyüklər üçün tutumunu yazın.")]
        [Range(1, 4, ErrorMessage = "4 nəfərdən artıq tutumu olan otaq yoxdur.")]
        [Display(Name = "Otaq Tutumu")]
        public int PersonCapacity { get; set; }


        [Required(ErrorMessage = "Otağın uşaqlar üçün tutumunu yazın.")]
        [Range(1, 4, ErrorMessage = "4 nəfər uşaqdan artıq tutumu olan otaq yoxdur.")]
        [Display(Name = "Otağın uşaq sayı tutumu")]
        public int ChildCapacity { get; set; }


        [Required(ErrorMessage = "Otaq haqqında məlumatları yazın.")]
        [MaxLength(500, ErrorMessage = "Otaq haqqında məlumatları maximum 500 xarakter olmalıdır.")]
        [MinLength(1, ErrorMessage = "Otaq haqqında məlumatları minimum 1 xarakter olmalıdır")]
        [Display(Name = "Otaq Haqqında")]
        public string Desc { get; set; }


        public List<Registration> Registrations { get; set; }

        public int BedTypeId { get; set; }
        public List<BedType> BedTypes { get; set; }


    }
}