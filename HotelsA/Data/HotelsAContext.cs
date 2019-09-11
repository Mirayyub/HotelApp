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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}