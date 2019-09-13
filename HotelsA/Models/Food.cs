using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsA.Models
{
    public class Food
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public bool? IsDelete { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}