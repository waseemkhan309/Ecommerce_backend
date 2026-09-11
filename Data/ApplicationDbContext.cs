using Ecommerce_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
      
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Buyer> Buyer { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem>  CartItems { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationAddress>  OrgAddress{ get; set;  }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductRating> Rating { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
    }
}
