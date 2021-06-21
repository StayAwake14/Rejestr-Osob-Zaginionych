using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RejestrOsóbZaginionych.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("conn")
        {

        }
     //   public DbSet<UserLogin> Users { get; set; }
     //   public DbSet<MissingPerson> MissingPersons { get; set; }

     //   public DbSet<AddMssingPerson> Persons { get; set; }

      //  public System.Data.Entity.DbSet<RejestrOsóbZaginionych.Models.UserRegister> UserRegisters { get; set; }

    //    public System.Data.Entity.DbSet<RejestrOsóbZaginionych.Models.AddMssingPerson> AddMssingPersons { get; set; }
    }
}