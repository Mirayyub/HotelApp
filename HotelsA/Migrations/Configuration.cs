namespace HotelsA.Migrations
{
    using HotelsA.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelsA.Data.HotelsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HotelsA.Data.HotelsContext _context)
        {
            UserRol usrr = new UserRol
            {
                UserType = "Administrator"
            };
            _context.UserRols.Add(usrr);

            User user = new User
            {
                FullName = "Administrator",
                UserName = "administrator",
                Password = "admin",
                UserRolId = 1
            };
            _context.Users.Add(user);

            BedType bdty1 = new BedType
            {
                TypeName = "Cüt"
            };
            _context.BedTypes.Add(bdty1);

            BedType bdty2 = new BedType
            {
                TypeName = "Tək"
            };
            _context.BedTypes.Add(bdty2);
            _context.SaveChanges();
        }
    }
}
