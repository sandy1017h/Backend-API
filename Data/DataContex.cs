using server.Entities;
using Microsoft.EntityFrameworkCore;

namespace server.Data
{
    public class DataContex:DbContext
    {
        private readonly IConfiguration _config;
        public DataContex(DbContextOptions<DataContex> options,IConfiguration config): base(options)
        {
            this._config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = _config["ConnectionStrings:Auth"]?? throw new Exception("Connection string missing");
            string dbName = _config["ConnectionStrings:DbName"]??throw new Exception("DbName Missing");
            string dbUser = _config["ConnectionStrings:DbUserId"]??throw new Exception("Db UserName Missing");
            string dbUserPassword = _config["ConnectionStrings:DbUserPassword"]??throw new Exception("Db User Password Missing");

            string ConnectionStrings = String.Format(conn, dbName, dbUser, dbUserPassword);

            optionsBuilder.UseSqlServer(ConnectionStrings);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.OriginalPrice).HasPrecision(18, 2);
                entity.Property(p => p.DiscountPercentage).HasColumnType("decimal(5,2)").IsRequired(false);
                entity.Property(p => p.DiscountAmount).HasColumnType("decimal(18,2)").IsRequired(false);
            });

            // First seed images
            modelBuilder.Entity<Image>().HasData(
                new Image { 
                    Id = 1,
                    Url = "https://images.unsplash.com/photo-1662947995643-0007c2b5ebb6?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fHNhbXN1bmclMjBsb2dvfGVufDB8fDB8fHww",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 2,
                    Url = "https://www.freeiconspng.com/thumbs/apple-logo-icon/blue-apple-logo-icon-0.png",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 3,
                    Url = "https://cdn.freebiesupply.com/logos/large/2x/sony-logo-png-transparent.png",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 4,
                    Url = "https://e7.pngegg.com/pngimages/255/673/png-clipart-dell-logo-illustration-dell-sonicwall-logo-dell-logo-blue-text-thumbnail.png",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 5,
                    Url = "https://i.pinimg.com/736x/a7/15/be/a715beeaceeba3b6fdbcb29717032cc8.jpg",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 6,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/2/24/Adidas_logo.png",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 7,
                    Url = "https://w7.pngwing.com/pngs/670/927/png-transparent-puma-logo-puma-logo-adidas-swoosh-brand-adidas-text-carnivoran-sneakers-thumbnail.png",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 8,
                    Url = "https://w7.pngwing.com/pngs/581/271/png-transparent-levi%C2%B4s-store-frolunda-torg-levi-strauss-co-brand-sweater-levi-text-label-rectangle-thumbnail.png",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 9,
                    Url = "https://w7.pngwing.com/pngs/675/344/png-transparent-lg-logo-lg-g5-lg-electronics-lg-corp-lg-logo-text-trademark-logo.png",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 10,
                    Url = "https://example.com/brands/whirlpool.png",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 11,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/1/10/Whirlpool_Corporation_Logo.png",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 12,
                    Url = "https://w7.pngwing.com/pngs/370/224/png-transparent-bosch-logo-thumbnail.png",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 13,
                    Url = "https://preview.redd.it/q1tkmm77nza31.png?auto=webp&s=fd0fe1175193ec462c1625eb28b02cea8e5eaae4",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 14,
                    Url = "https://www.liblogo.com/img-logo/ha1286h474-harpercollins-logo-harpercollins-javelin.png",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 15,
                    Url = "https://logowik.com/content/uploads/images/simon-data6544.logowik.com.webp",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 16,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/5/5e/Hachette_India_logo.png",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 17,
                    Url = "https://w7.pngwing.com/pngs/342/57/png-transparent-nestle-logo-nestle-logo-nestle-ghana-ltd-nestle-blue-angle-building-thumbnail.png",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 18,
                    Url = "https://m.economictimes.com/thumb/msid-76233259,width-1200,height-900,resizemode-4,imgsize-672052/amul.jpg",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 19,
                    Url = "https://upload.wikimedia.org/wikipedia/en/thumb/5/50/Britannia_Industries_logo_with_motto.svg/2560px-Britannia_Industries_logo_with_motto.svg.png",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Image { 
                    Id = 20,
                    Url = "https://www.yogaiya.in/wp-content/uploads/2018/08/Patanjali-Yogpeeth.jpg",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                }
            );

            // Then seed categories
            modelBuilder.Entity<Category>().HasData(
                new Category { 
                    Id = 1,
                    Name = "Electronics",
                    Description = "Electronic gadgets and devices",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Category { 
                    Id = 2,
                    Name = "Fashion",
                    Description = "Clothing and fashion accessories",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Category { 
                    Id = 3,
                    Name = "Home Appliances",
                    Description = "Appliances for home use",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Category { 
                    Id = 4,
                    Name = "Books",
                    Description = "Books from various genres",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Category { 
                    Id = 5,
                    Name = "Groceries",
                    Description = "Daily essentials and groceries",
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                }
            );

            // Then seed brands with ImageIds
            modelBuilder.Entity<Brand>().HasData(
                // Electronics Brands
                new Brand
                {
                    Id = 1,
                    Name = "Samsung",
                    ImageId = 1,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 2,
                    Name = "Apple",
                    ImageId = 2,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 3,
                    Name = "Sony",
                    ImageId = 3,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 4,
                    Name = "Dell",
                    ImageId = 4,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },

                // Fashion Brands
                new Brand
                {
                    Id = 5,
                    Name = "Nike",
                    ImageId = 5,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 6,
                    Name = "Adidas",
                    ImageId = 6,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 7,
                    Name = "Puma",
                    ImageId = 7,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 8,
                    Name = "Levi's",
                    ImageId = 8,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },

                // Home Appliances Brands
                new Brand
                {
                    Id = 9,
                    Name = "LG",
                    ImageId = 9,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 10,
                    Name = "Whirlpool",
                    ImageId = 10,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 11,
                    Name = "Philips",
                    ImageId = 11,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 12,
                    Name = "Bosch",
                    ImageId = 12,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },

                // Books Brands
                new Brand
                {
                    Id = 13,
                    Name = "Penguin Random House",
                    ImageId = 13,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 14,
                    Name = "HarperCollins",
                    ImageId = 14,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 15,
                    Name = "Simon & Schuster",
                    ImageId = 15,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 16,
                    Name = "Hachette",
                    ImageId = 16,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },

                // Groceries Brands
                new Brand
                {
                    Id = 17,
                    Name = "Nestlé",
                    ImageId = 17,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 18,
                    Name = "Amul",
                    ImageId = 18,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 19,
                    Name = "Britannia",
                    ImageId = 19,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 20,
                    Name = "Patanjali",
                    ImageId = 20,
                    CreatedDate = new DateTime(2024, 1, 1),
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    IsDeleted = false
                }
            );

            // Configure relationships before seeding
            modelBuilder.Entity<Brand>()
                .HasOne(p => p.Image)
                .WithOne(i => i.Brand)
                .HasForeignKey<Brand>(b => b.ImageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasOne(p => p.Image)
                .WithOne(i => i.Category)
                .HasForeignKey<Category>(c => c.ImageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Thumbnail)
                .WithOne(i => i.Product)
                .HasForeignKey<Product>(p => p.ThumbnailId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is AuditBaseEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = now;
                            break;

                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                            entity.ModifiedDate = now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<User> users { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Image> images { get; set; }

        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<Wishlist> Wishlists {  get; set; }

        public DbSet<ShoppingCartItem> ShopcartItems { get; set; }
        public DbSet<ShoppingCart> Shopcarts { get;  set; }

         public DbSet<ProductReview> ProductReviews { get;  set; }

         public DbSet<Address> Address { get; set; }

         public DbSet<OrderItem> OrderItems { get; set; }
         public DbSet<Order> Orders { get; set; }
        public DbSet<Orders> ProductOrders { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }  // Add PaymentTransactions table

    }
}

