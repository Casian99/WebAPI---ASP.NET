using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using proiectASP.NET.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectASP.NET.Data
{
    public class ProiectContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ProiectContext(DbContextOptions<ProiectContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Camera> Camere { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RezervareClientHotel> RezervariClientHotel { get; set; }
        public DbSet<SessionToken> SessionTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to Many

            modelBuilder.Entity<Hotel>()
                .HasMany(a => a.Camere)
                .WithOne(b => b.Hotel);

            // One to One

            modelBuilder.Entity<Hotel>()
                .HasOne(a => a.Manager)
                .WithOne(m => m.Hotel);

            // Many to Many

            modelBuilder.Entity<RezervareClientHotel>().HasKey(rch => new { rch.HotelId, rch.ClientId });

            modelBuilder.Entity<RezervareClientHotel>()
                .HasOne(rch => rch.Hotel)
                .WithMany(a => a.RezervariClientHotel)
                .HasForeignKey(rch => rch.HotelId);

            modelBuilder.Entity<RezervareClientHotel>()
                .HasOne(rch => rch.Client)
                .WithMany(a => a.RezervariClientHotel)
                .HasForeignKey(rch => rch.ClientId);


            // userrole Relation

            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);

            });


            base.OnModelCreating(modelBuilder);
        }


    }
}

