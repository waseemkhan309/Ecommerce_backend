using Ecommerce_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // buyer --> Address (One-to-Many)
            modelBuilder.Entity<Buyer>()
                .HasMany(b => b.Addresses)
                .WithOne(a => a.Buyer)
                .HasForeignKey(a => a.BuyerId)
                .OnDelete(DeleteBehavior.Cascade);

            // seller --> Address (One-to-Many)
            modelBuilder.Entity<Seller>()
                .HasMany(s => s.Addresses)
                .WithOne(a => a.Seller)
                .HasForeignKey(a => a.SellerId)
                .OnDelete(DeleteBehavior.Cascade);


            // buyer --> Comment (One-to-Many)
            modelBuilder.Entity<Buyer>()
                .HasMany(b => b.Comments)
                .WithOne(c => c.Buyer)
                .HasForeignKey(c => c.BuyerId)
                .OnDelete(DeleteBehavior.Cascade);


            // Seller --> Organizations (One-to-Many)
            modelBuilder.Entity<Seller>()
                .HasMany(s => s.Organizations)
                .WithOne(o => o.Seller)
                .HasForeignKey(o => o.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Organization --> Product (One-to-Many)
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.Products)
                .WithOne(p => p.Organization)
                .HasForeignKey(p => p.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);

            // Organization --> OrganizationAddress (One-to-Many)
            modelBuilder.Entity<Organization>()
                .HasMany(or => or.OrganizationAddresses)
                .WithOne(oa => oa.Organization)
                .HasForeignKey(oa => oa.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);


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
