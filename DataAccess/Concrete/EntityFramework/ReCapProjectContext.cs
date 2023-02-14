using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    
        //context: db tabloları ile proje classlarını ilişkilendirmeye yarar. Aynı zamnada vt bağlantısıda burda yapılır 
        public class ReCapProjectContext : DbContext //contextein kendisi. Kurulan entityframework ile beraber gelir 
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ReCapProject;Trusted_Connection=true"); //burda hangi vt tabanına bağlanacağımızı söyleyeceğiz
            }

            public DbSet<Car> Cars { get; set; } //benim car nesnemi vt cars nesnesi ile bağla
            public DbSet<Color> Colors { get; set; }
            public DbSet<Brand> Brands { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Rental> Rentals { get; set; }
            public DbSet<CarImage> CarImages { get; set; }
            public DbSet<OperationClaim> OperationClaims { get; set; }
            public DbSet<UserOperationClaim> UserOperationClaims { get; set; }




    }
}
