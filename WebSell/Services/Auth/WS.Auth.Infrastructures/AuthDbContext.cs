using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Auth.Domain;

namespace WS.Auth.Infrastructures
{
    public class AuthDbContext : DbContext
    {
        public DbSet<AuthUser> Users { get; set; }
        public DbSet<AuthRole> Roles { get; set; }
        public DbSet<AuthUserRole> UserRoles { get; set; }
        public DbSet<AuthRolePermission> RolePermissions { get; set; }


        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthUserRole>().HasOne<AuthUser>().WithMany().HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AuthUserRole>().HasOne<AuthRole>().WithMany().HasForeignKey(e => e.RoleId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AuthRolePermission>().HasOne<AuthRole>().WithMany().HasForeignKey(e => e.RoleId).OnDelete(DeleteBehavior.Restrict);
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
