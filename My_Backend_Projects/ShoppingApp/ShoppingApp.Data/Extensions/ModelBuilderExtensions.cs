using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Entity.Concrete;
using ShoppingApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region RolBilgileri
            List<Role> roles = new List<Role>
            {
                new Role
                {
                    Name="Admin",
                    Description="Admin rolü",
                    NormalizedName="ADMIN"
                },
                new Role
                {
                    Name="User",
                    Description="User rolü",
                    NormalizedName="USER"
                }
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion

            #region KullanıcıBilgileri
            List<User> users = new List<User>
            {
                new User
                {
                    FirstName="Deniz",
                    LastName="Admin",
                    UserName="admin",
                    NormalizedUserName="ADMIN",
                    Gender="Kadın",
                    DateOfBirth=new DateTime(1998,5,19),
                    Email="admin@gmail.com",
                    NormalizedEmail="ADMIN@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="5555555555",
                    Address="Çek cd. Senet sk. Fatura ap.",
                    City="İstanbul"
                },
                new User
                {
                    FirstName="Kemal",
                    LastName="User",
                    UserName="user",
                    NormalizedUserName="USER",
                    Gender="Erkek",
                    DateOfBirth=new DateTime(1985,10,29),
                    Email="user@gmail.com",
                    NormalizedEmail="USER@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="4444444444",
                    Address="Akasya cd. Orkide sk. Gül ap.",
                    City="İzmir"
                }
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region Parolaİşlemleri
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            #endregion

            #region KullanıcıRolAtamaİşlemleri
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId=users[0].Id,
                    RoleId=roles.First(r=>r.Name=="Admin").Id
                },
                new IdentityUserRole<string>
                {
                    UserId=users[1].Id,
                    RoleId=roles.First(r=>r.Name=="User").Id
                }
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion

            #region AlışverişSepetiİşlemleri
            List<Card> cards = new List<Card>
            {
                new Card { Id=1, UserId=users[0].Id},
                new Card { Id=2, UserId=users[1].Id}
            };
            modelBuilder.Entity<Card>().HasData(cards);
            #endregion
        }
    }
}
