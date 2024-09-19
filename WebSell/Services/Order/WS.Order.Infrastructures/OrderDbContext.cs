using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Order.Domain;

namespace WS.Order.Infrastructures
{
    public class OrderDbContext : DbContext
    {
        public DbSet<OrderCart> Carts { get; set; }
        public DbSet<OrderPurchase> Purchases { get; set; }
        public DbSet<OrderDetailPurchase> Details { get; set; }

        public OrderDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetailPurchase>().HasOne<OrderPurchase>().WithMany().HasForeignKey(d => d.PurchaseId).OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
    }
}
