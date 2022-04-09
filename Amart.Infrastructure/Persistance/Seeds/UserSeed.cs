using Amart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amart.Infrastructure.Persistance.Seeds
{
    public static class UserSeed
    {
        internal static ModelBuilder AddUserSeedData(this ModelBuilder builder)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Login = "Admin",
                Password = "12345678",
                Created = DateTime.Now
            };

            builder.Entity<User>().HasData(user);

            return builder;
        }
    }
}
