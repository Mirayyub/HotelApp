using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsA.Models
{
    public class RestourantOrder
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int FoodId { get; set; }

        public Food Food { get; set; }

        public int FoodCount { get; set; }

        public bool? IsDelete { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}