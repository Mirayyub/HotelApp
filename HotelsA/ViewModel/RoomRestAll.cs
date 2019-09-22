using HotelsA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsA.ViewModel
{
    public class RoomRestAll
    {
        public List<Room> Rooms { get; set; }

        public List<RestourantOrder> RestourantOrders { get; set; }
    }
}