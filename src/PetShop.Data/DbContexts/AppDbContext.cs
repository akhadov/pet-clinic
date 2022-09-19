using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Constants;
using PetShop.Domain.Entities;

namespace PetShop.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseNpgsql(DbConstants.CONNECTION_STRING);
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<OrderPet> Sales { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
