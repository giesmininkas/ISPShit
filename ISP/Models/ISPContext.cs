using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ISP
{
    public partial class ISPContext : DbContext
    {
        public ISPContext()
        {
        }

        public ISPContext(DbContextOptions<ISPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<CartsHasItems> CartsHasItems { get; set; }
        public virtual DbSet<ItemCategories> ItemCategories { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Manufacturers> Manufacturers { get; set; }
        public virtual DbSet<PackingMaterials> PackingMaterials { get; set; }
        public virtual DbSet<PaymentTypes> PaymentTypes { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<ShippingTypes> ShippingTypes { get; set; }
        public virtual DbSet<UserAddresses> UserAddresses { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Warehouses> Warehouses { get; set; }
        public virtual DbSet<WarehousesHasItems> WarehousesHasItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;Database=ISP;User=root;Password=password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.0.0-preview.18572.1");

            modelBuilder.Entity<Bills>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UsersId, e.AddressId, e.ShippingTypeId, e.CartId, e.PaymentTypeId });

                entity.ToTable("bills", "ISP");

                entity.HasIndex(e => e.AddressId)
                    .HasName("fk_bills_user_addresses1_idx");

                entity.HasIndex(e => e.CartId)
                    .HasName("fk_bills_carts1_idx");

                entity.HasIndex(e => e.PaymentTypeId)
                    .HasName("fk_bills_payment_type1_idx");

                entity.HasIndex(e => e.ShippingTypeId)
                    .HasName("fk_bills_shipping_types1_idx");

                entity.HasIndex(e => e.UsersId)
                    .HasName("fk_bills_users1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UsersId)
                    .HasColumnName("users_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ShippingTypeId)
                    .HasColumnName("shipping_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CartId)
                    .HasColumnName("cart_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PaymentTypeId)
                    .HasColumnName("payment_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BillingDate).HasColumnName("billing_date");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("payment_date")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bills_payment_type1");

                entity.HasOne(d => d.ShippingType)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.ShippingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bills_shipping_types1");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bills_users1");
            });

            modelBuilder.Entity<Carts>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PackingMaterialId });

                entity.ToTable("carts", "ISP");

                entity.HasIndex(e => e.PackingMaterialId)
                    .HasName("fk_carts_packing_materials1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PackingMaterialId)
                    .HasColumnName("packing_material_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.PackingMaterial)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.PackingMaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_carts_packing_materials1");
            });

            modelBuilder.Entity<CartsHasItems>(entity =>
            {
                entity.HasKey(e => new { e.CartId, e.ItemId });

                entity.ToTable("carts_has_items", "ISP");

                entity.HasIndex(e => e.CartId)
                    .HasName("fk_cart_has_items_cart1_idx");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_cart_has_items_items1_idx");

                entity.Property(e => e.CartId)
                    .HasColumnName("cart_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<ItemCategories>(entity =>
            {
                entity.ToTable("item_categories", "ISP");

                entity.HasIndex(e => e.ParentId)
                    .HasName("fk_item_categories_item_categories_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)")
                    .IsRequired(false);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_item_categories_item_categories");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CategoryId });

                entity.ToTable("items", "ISP");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("fk_items_item_categories1_idx");

                entity.HasIndex(e => e.ManufacturerId)
                    .HasName("fk_items_manufacturers1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(true);

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.ManufacturerId)
                    .HasColumnName("manufacturer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Width).HasColumnName("width");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_items_item_categories1");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_items_manufacturers1");
            });

            modelBuilder.Entity<Manufacturers>(entity =>
            {
                entity.ToTable("manufacturers", "ISP");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<PackingMaterials>(entity =>
            {
                entity.ToTable("packing_materials", "ISP");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasMaxLength(45)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<PaymentTypes>(entity =>
            {
                entity.ToTable("payment_types", "ISP");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UserId, e.ItemId });

                entity.ToTable("reviews", "ISP");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_reviews_items1_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_reviews_users1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(true);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reviews_users1");
            });

            modelBuilder.Entity<ShippingTypes>(entity =>
            {
                entity.ToTable("shipping_types", "ISP");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<UserAddresses>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UserId });

                entity.ToTable("user_addresses", "ISP");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_user_addresses_users1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.Property(e => e.PhoneNr)
                    .HasColumnName("phone_nr")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_addresses_users1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users", "ISP");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(500)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Warehouses>(entity =>
            {
                entity.ToTable("warehouses", "ISP");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(45)
                    .IsUnicode(true);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(45)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<WarehousesHasItems>(entity =>
            {
                entity.HasKey(e => new { e.WarehouseId, e.ItemId });

                entity.ToTable("warehouses_has_items", "ISP");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_warehouses_has_items_items1_idx");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("fk_warehouses_has_items_warehouses1_idx");

                entity.Property(e => e.WarehouseId)
                    .HasColumnName("warehouse_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.WarehousesHasItems)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_warehouses_has_items_warehouses1");
            });
        }
    }
}
