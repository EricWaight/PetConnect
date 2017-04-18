using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PetConnect.Models;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace PetConnect.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public MyDBContext() : base ("PetConnectContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Chirps> Chirps { get; set; }
    }
}