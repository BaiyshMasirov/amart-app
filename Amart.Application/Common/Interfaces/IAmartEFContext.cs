using Amart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Amart.Application.Common.Interfaces
{
    public interface IAmartEFContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<OrderProduct> OrderProducts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}