using System.Collections.Generic;

namespace Amart.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public IList<Order> Orders { get; set; }

        public User()
        {
            Orders = new List<Order>();
        }
    }
}