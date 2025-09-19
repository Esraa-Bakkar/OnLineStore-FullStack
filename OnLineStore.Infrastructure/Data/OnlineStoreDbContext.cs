using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Domain.Entities;


namespace OnLineStore.Infrastructure.Data;

public partial class OnlineStoreDbContext : DbContext
{
    public OnlineStoreDbContext()
    {
    }

    public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Catagory> Catagories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Online_store;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.TId).HasName("PK__cart__83BB1FB2C45EA22C");

            entity.ToTable("cart");

            entity.Property(e => e.TId)
                .ValueGeneratedNever()
                .HasColumnName("T_ID");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.UId).HasColumnName("U_ID");

            entity.HasOne(d => d.UIdNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UId)
                .HasConstraintName("FK__cart__U_ID__3D5E1FD2");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__cart_ite__A3420A77B4AE4BA1");

            entity.ToTable("cart_item");

            entity.Property(e => e.PId)
                .ValueGeneratedNever()
                .HasColumnName("P_ID");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TId).HasColumnName("T_ID");

            entity.HasOne(d => d.PIdNavigation).WithOne(p => p.CartItem)
                .HasForeignKey<CartItem>(d => d.PId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cart_item__P_ID__46E78A0C");

            entity.HasOne(d => d.TIdNavigation).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.TId)
                .HasConstraintName("FK__cart_item__T_ID__47DBAE45");
        });

        modelBuilder.Entity<Catagory>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__catagory__A9FDEC12AFAD3BAB");

            entity.ToTable("catagory");

            entity.Property(e => e.CId)
                .ValueGeneratedOnAdd()
                .HasColumnName("C_ID");
            entity.Property(e => e.CName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("C_name");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OId).HasName("PK___Order__5AAB0C18D36137AC");

            entity.ToTable("_Order");

            entity.Property(e => e.OId)
                .ValueGeneratedNever()
                .HasColumnName("O_ID");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Paid).HasColumnName("paid");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TId).HasColumnName("T_ID");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Total_Price");
            entity.Property(e => e.UId).HasColumnName("U_ID");

            entity.HasOne(d => d.TIdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TId)
                .HasConstraintName("FK___Order__T_ID__440B1D61");

            entity.HasOne(d => d.UIdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UId)
                .HasConstraintName("FK___Order__U_ID__4316F928");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__product__A3420A777D846025");

            entity.ToTable("product");

            entity.Property(e => e.PId)
                .ValueGeneratedNever()
                .HasColumnName("P_ID");
            entity.Property(e => e.CId).HasColumnName("C_ID");
            entity.Property(e => e.ImgePath)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("imge_path");
            entity.Property(e => e.PName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("P_name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CId)
                .HasConstraintName("FK__product__C_ID__403A8C7D");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.RId).HasName("PK__Review__DE152E899061AB71");

            entity.ToTable("Review");

            entity.Property(e => e.RId)
                .ValueGeneratedNever()
                .HasColumnName("R_ID");
            entity.Property(e => e.Comment)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.PId).HasColumnName("P_ID");
            entity.Property(e => e.Rating).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UId).HasColumnName("U_ID");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.PId)
                .HasConstraintName("FK__Review__P_ID__4BAC3F29");

            entity.HasOne(d => d.UIdNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UId)
                .HasConstraintName("FK__Review__U_ID__4AB81AF0");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("PK___User__5A2040DB134DBC93");

            entity.ToTable("_User");

            entity.Property(e => e.UId)
                .ValueGeneratedNever()
                .HasColumnName("U_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.UName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("U_name");
            entity.Property(e => e.UidNew)
                .ValueGeneratedOnAdd()
                .HasColumnName("UId_New");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}