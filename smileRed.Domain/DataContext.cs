using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smileRed.Domain
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<smileRed.Domain.User> Users { get; set; }

        public System.Data.Entity.DbSet<smileRed.Domain.TypeofUser> TypeofUsers { get; set; }

        public System.Data.Entity.DbSet<smileRed.Domain.Product> Products { get; set; }

        public System.Data.Entity.DbSet<smileRed.Domain.Group> Groups { get; set; }

        public System.Data.Entity.DbSet<smileRed.Domain.Admixtures> Admixtures { get; set; }

        public System.Data.Entity.DbSet<smileRed.Backend.Controllers.Nutrition> Nutritions { get; set; }

        public System.Data.Entity.DbSet<smileRed.Domain.Offert> Offerts { get; set; }

        public System.Data.Entity.DbSet<smileRed.Domain.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<smileRed.Domain.OrderStatus> OrderStatus { get; set; }

        public System.Data.Entity.DbSet<smileRed.Domain.OrderDetails> OrderDetails { get; set; }

        public System.Data.Entity.DbSet<smileRed.Domain.Contacts> Contacts { get; set; }

        public System.Data.Entity.DbSet<smileRed.Domain.Favorite> Favorites { get; set; }

        public System.Data.Entity.DbSet<smileRed.Domain.Reservation> Reservations { get; set; }
    }
}