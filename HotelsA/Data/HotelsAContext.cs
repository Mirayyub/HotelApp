using HotelsA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelsA.Data
{
    public class HotelsAContext :DbContext
    {
        public HotelsAContext() : base("HotelsAContext")
        {

        }
        public DbSet<BedType> BedTypes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRol> UserRols { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<RestourantOrder> RestourantOrders { get; set; }

    }
}