namespace RejestrOsóbZaginionych.Controllers
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using RejestrOsóbZaginionych.Models;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ROZ")
        {
        }

        public DbSet<missingPersons> MissingPersons { get; set; }
        public DbSet<users> Users { get; set; }
        public System.Data.Entity.DbSet<RejestrOsóbZaginionych.Models.UserRegister> UserRegisters { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<missingPersons>()
                .Property(e => e.imie)
                .IsUnicode(false);

            modelBuilder.Entity<missingPersons>()
                .Property(e => e.nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<missingPersons>()
                .Property(e => e.plec)
                .IsFixedLength();

            modelBuilder.Entity<missingPersons>()
                .Property(e => e.wojewodztwo)
                .IsUnicode(false);

            modelBuilder.Entity<missingPersons>()
                .Property(e => e.opis)
                .IsUnicode(false);

            modelBuilder.Entity<missingPersons>()
                .Property(e => e.obraz)
                .IsFixedLength();

            modelBuilder.Entity<missingPersons>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.rank)
                .IsUnicode(false);
        }
    }
}
