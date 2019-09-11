using HotelsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelsApp.Data
{
    public class DefaultConnection:DbContext
    {
        public DefaultConnection() : base("DefaultConnection")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}