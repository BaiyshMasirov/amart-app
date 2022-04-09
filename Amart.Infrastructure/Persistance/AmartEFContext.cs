using Amart.Application.Common.Interfaces;
using Amart.Domain.Entities;
using Amart.Infrastructure.Persistance.Seeds;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Amart.Infrastructure.Persistance
{
    public class AmartEFContext : DbContext, IAmartEFContext
    {
        public AmartEFContext(DbContextOptions<AmartEFContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

            builder.AddUserSeedData();
            builder.AddProductSeedData();
        }
    }
}