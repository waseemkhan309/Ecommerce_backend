
using Ecommerce_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_backend.Data
{
    /// <summary>
    /// Custom initializer: runs at app startup, is idempotent (safe to run many times).
    /// Replace ApplicationDbContext with the name of your actual DbContext.
    /// </summary>
    public static class DbInitializer
    {
        // Sync version required by UseSeeding (EF Core calls this from Migrate / database update)
        public static void Seed(ApplicationDbContext context)
            => SeedAsync(context).GetAwaiter().GetResult();

        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // Run-once guard: if ANY seeded table already has rows, skip everything.
            // This makes running the migration command repeatedly safe (no duplicates).
            if (await context.Role.AnyAsync()
                || await context.Category.AnyAsync()
                || await context.Seller.AnyAsync()
                || await context.Buyer.AnyAsync())
                return;

            var now = DateTime.UtcNow;

            // ---------- Roles & Permissions ----------
            var adminRole = new Role { Id = Guid.NewGuid(), Name = "Admin", Description = "Full access", CreatedAt = now, UpdatedAt = now };
            var sellerRole = new Role { Id = Guid.NewGuid(), Name = "Seller", Description = "Manage own products", CreatedAt = now, UpdatedAt = now };
            var buyerRole = new Role { Id = Guid.NewGuid(), Name = "Buyer", Description = "Shop and order", CreatedAt = now, UpdatedAt = now };
            context.Role.AddRange(adminRole, sellerRole, buyerRole);

            var permissions = new[] { "Product.Create", "Product.Update", "Product.Delete", "Product.View", "Order.Create", "Order.View", "User.Manage" }
                .Select(n => new Permission { Id = Guid.NewGuid(), Name = n, CreatedAt = now, UpdatedAt = now })
                .ToList();
            context.Permissions.AddRange(permissions);

            Permission P(string name) => permissions.First(p => p.Name == name);

            void Grant(Role role, params string[] names)
            {
                foreach (var n in names)
                {
                    // Set only FKs; leave navigations null so EF doesn't insert the "new Role()" defaults
                    context.RolePermissions.Add(new RolePermission
                    {
                        Id = Guid.NewGuid(),
                        RoleId = role.Id,
                        PermissionId = P(n).Id,
                        Role = role,
                        permission = P(n),
                        CreatedAt = now,
                        UpdatedAt = now
                    });
                }
            }

            Grant(adminRole, permissions.Select(p => p.Name).ToArray());
            Grant(sellerRole, "Product.Create", "Product.Update", "Product.Delete", "Product.View", "Order.View");
            Grant(buyerRole, "Product.View", "Order.Create", "Order.View");

            // ---------- Categories ----------
            var electronics = new Category { Id = Guid.NewGuid(), Name = "Electronics", Description = "Phones, laptops, gadgets", CreatedAt = now, UpdatedAt = now };
            var fashion = new Category { Id = Guid.NewGuid(), Name = "Fashion", Description = "Clothing and accessories", CreatedAt = now, UpdatedAt = now };
            var home = new Category { Id = Guid.NewGuid(), Name = "Home & Kitchen", Description = "Home essentials", CreatedAt = now, UpdatedAt = now };
            context.Category.AddRange(electronics, fashion, home);

            // ---------- Sellers ----------
            var sellerHasher = new PasswordHasher<Seller>();
            var seller1 = new Seller
            {
                Id = Guid.NewGuid(),
                UserName = "techhub",
                FirstName = "Ali",
                LastName = "Khan",
                Email = "ali@techhub.com",
                PhoneNumber = "+923001112233",
                IsEmailVerified = true,
                IsPhoneNumberVerified = true,
                Country = "Pakistan",
                Gender = "Male",
                CreatedAt = now,
                UpdatedAt = now
            };
            seller1.PasswordHash = BCrypt.Net.BCrypt.HashPassword("Seller@123");

            var seller2 = new Seller
            {
                Id = Guid.NewGuid(),
                UserName = "stylestore",
                FirstName = "Sara",
                LastName = "Ahmed",
                Email = "sara@stylestore.com",
                PhoneNumber = "+923004445566",
                IsEmailVerified = true,
                IsPhoneNumberVerified = true,
                Country = "Pakistan",
                Gender = "Female",
                CreatedAt = now,
                UpdatedAt = now
            };
            seller2.PasswordHash = BCrypt.Net.BCrypt.HashPassword("Seller@123");
            context.Seller.AddRange(seller1, seller2);

            // ---------- Buyers ----------
            var buyerHasher = new PasswordHasher<Buyer>();
            var buyer1 = new Buyer
            {
                Id = Guid.NewGuid(),
                UserName = "john_doe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com",
                PhoneNumber = "+923211234567",
                IsEmailVerified = true,
                IsPhoneNumberVerified = true,
                Gender = "Male",
                Country = "Pakistan",
                CreatedAt = now,
                UpdatedAt = now
            };
            buyer1.PasswordHash = BCrypt.Net.BCrypt.HashPassword("Buyer@123");

            var buyer2 = new Buyer
            {
                Id = Guid.NewGuid(),
                UserName = "jane_smith",
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane@example.com",
                PhoneNumber = "+923217654321",
                IsEmailVerified = true,
                IsPhoneNumberVerified = false,
                Gender = "Female",
                Country = "Pakistan",
                CreatedAt = now,
                UpdatedAt = now
            };
            buyer2.PasswordHash = BCrypt.Net.BCrypt.HashPassword("Buyer@123");
            //buyerHasher.HashPassword(buyer2, "Buyer@123");
            context.Buyer.AddRange(buyer1, buyer2);

            // ---------- Addresses (either BuyerId or SellerId) ----------
            context.Address.AddRange(
                new Address { Id = Guid.NewGuid(), Street = "12 Main Blvd", City = "Lahore", State = "Punjab", PostalCode = "54000", Area = "Gulberg", Country = "Pakistan", BuyerId = buyer1.Id, CreatedAt = now, UpdatedAt = now },
                new Address { Id = Guid.NewGuid(), Street = "45 Canal Road", City = "Lahore", State = "Punjab", PostalCode = "54600", Area = "Model Town", Country = "Pakistan", BuyerId = buyer2.Id, CreatedAt = now, UpdatedAt = now },
                new Address { Id = Guid.NewGuid(), Street = "7 Market Street", City = "Karachi", State = "Sindh", PostalCode = "75500", Area = "Saddar", Country = "Pakistan", SellerId = seller1.Id, CreatedAt = now, UpdatedAt = now },
                new Address { Id = Guid.NewGuid(), Street = "88 Mall Road", City = "Islamabad", State = "ICT", PostalCode = "44000", Area = "F-7", Country = "Pakistan", SellerId = seller2.Id, CreatedAt = now, UpdatedAt = now }
            );

            // ---------- Organizations ----------
            // Seller = null! overrides the "= new Seller()" default so EF doesn't insert a blank seller
            var org1 = new Organization
            {
                Id = Guid.NewGuid(),
                Name = "TechHub Pvt Ltd",
                OrgainationURL = "https://techhub.example.com",
                Description = "Consumer electronics retailer",
                SellerId = seller1.Id,
                seller = null!,
                CreatedAt = now,
                UpdatedAt = now
            };
            var org2 = new Organization
            {
                Id = Guid.NewGuid(),
                Name = "Style Store",
                OrgainationURL = "https://stylestore.example.com",
                Description = "Fashion and apparel",
                SellerId = seller2.Id,
                seller = null!,
                CreatedAt = now,
                UpdatedAt = now
            };
            context.Organizations.AddRange(org1, org2);

            // ---------- Products ----------
            Product NewProduct(string name, string desc, decimal price, decimal discount, int stock,
                               Category cat, Organization org, Seller seller) => new()
                               {
                                   Id = Guid.NewGuid(),
                                   Name = name,
                                   Description = desc,
                                   Price = price,
                                   Discount = discount,
                                   Stock = stock,
                                   CategoryId = cat.Id,
                                   OrganizationId = org.Id,
                                   SellerId = seller.Id,
                                   Seller = null!, // avoid default "new Seller()"
                                   CreatedAt = now,
                                   UpdatedAt = now
                               };

            var phone = NewProduct("Smartphone X", "6.5\" OLED, 128GB", 399.99m, 10m, 50, electronics, org1, seller1);
            var laptop = NewProduct("UltraBook 14", "14\" laptop, 16GB RAM", 899.00m, 5m, 20, electronics, org1, seller1);
            var shirt = NewProduct("Cotton T-Shirt", "100% cotton, regular fit", 19.99m, 0m, 200, fashion, org2, seller2);
            var jacket = NewProduct("Winter Jacket", "Water-resistant jacket", 79.50m, 15m, 60, fashion, org2, seller2);
            var products = new[] { phone, laptop, shirt, jacket };
            context.Product.AddRange(products);

            // ---------- Product Images ----------
            foreach (var p in products)
            {
                context.ProductImages.Add(new ProductImages
                {
                    Id = Guid.NewGuid(),
                    ProductId = p.Id,
                    Product = null!,
                    ImageUrl = $"https://picsum.photos/seed/{p.Id}/600/600",
                    CreatedAt = now,
                    UpdatedAt = now
                });
            }

            // ---------- Ratings & Comments ----------
            context.Rating.AddRange(
                new ProductRating { Id = Guid.NewGuid(), ProductId = phone.Id, BuyerId = buyer1.Id, Rating = 5, Comment = "Excellent phone!", CreatedAt = now, UpdatedAt = now },
                new ProductRating { Id = Guid.NewGuid(), ProductId = shirt.Id, BuyerId = buyer2.Id, Rating = 4, Comment = "Good quality for the price.", CreatedAt = now, UpdatedAt = now }
            );
            context.Comments.AddRange(
                new Comment { Id = Guid.NewGuid(), ProductId = phone.Id, BuyerId = buyer2.Id, Content = "Does it support fast charging?", CreatedAt = now, UpdatedAt = now },
                new Comment { Id = Guid.NewGuid(), ProductId = laptop.Id, BuyerId = buyer1.Id, Content = "Is the RAM upgradeable?", CreatedAt = now, UpdatedAt = now }
            );

            // ---------- Wishlists ----------
            var wishlist = new Wishlist { Id = Guid.NewGuid(), BuyerId = buyer1.Id, Buyer = null!, CreatedAt = now, UpdatedAt = now };
            context.Wishlist.Add(wishlist);
            context.WishlistItems.AddRange(
                new WishlistItem { Id = Guid.NewGuid(), WishlistId = wishlist.Id, Wishlist = null!, ProductId = laptop.Id, Product = null!, CreatedAt = now, UpdatedAt = now },
                new WishlistItem { Id = Guid.NewGuid(), WishlistId = wishlist.Id, Wishlist = null!, ProductId = jacket.Id, Product = null!, CreatedAt = now, UpdatedAt = now }
            );

            // ---------- Cart ----------
            var cart = new Cart { Id = Guid.NewGuid(), BuyerId = buyer2.Id, Buyer = buyer2, CreatedAt = now, UpdatedAt = now };
            cart.CartItems.Add(new CartItem { Id = Guid.NewGuid(), ProductId = shirt.Id, Product = null!, Quantity = 2, Price = shirt.Price, CreatedAt = now, UpdatedAt = now });
            cart.CartItems.Add(new CartItem { Id = Guid.NewGuid(), ProductId = jacket.Id, Product = null!, Quantity = 1, Price = jacket.Price, CreatedAt = now, UpdatedAt = now });
            context.Cart.Add(cart);

            // ---------- Orders ----------
            var order = new Order
            {
                Id = Guid.NewGuid(),
                OrderDate = now,
                BuyerId = buyer1.Id,
                Buyer = null!,
                Status = OrderStatus.Confirmed,
                Subtotal = 399,
                Discount = 40m,
                ShippingFee = 5.0,
                TotalAmount = 364,
                ShippingAddress = "12 Main Blvd, Gulberg, Lahore, Punjab, 54000, Pakistan",
                CreatedAt = now,
                UpdatedAt = now
            };
            context.Order.Add(order);
            context.OrderItems.Add(new OrderItems
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                Order = null!,
                ProductId = phone.Id,
                Product = null!,
                Quantity = 1,
                UnitPrice = phone.Price,
                TotalPrice = phone.Price,
                CreatedAt = now,
                UpdatedAt = now
            });

            await context.SaveChangesAsync();
        }
    }
}

