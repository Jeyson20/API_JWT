using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API_JWT.Models
{
    public partial class PruebaJWTContext : DbContext
    {
        public PruebaJWTContext()
        {
        }

        public PruebaJWTContext(DbContextOptions<PruebaJWTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SalesDetail> SalesDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=PruebaJWT;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("PK__Customer__DB43864AC8A2BBBD");

                entity.ToTable("Customer");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProducts)
                    .HasName("PK__Products__0988921C7DD4CD62");

                entity.Property(e => e.Cost).HasColumnType("numeric(9, 2)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnType("numeric(9, 2)");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.IdSale)
                    .HasName("PK__Sale__A04F9B37A91A41ED");

                entity.ToTable("Sale");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("numeric(9, 3)");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk1");
            });

            modelBuilder.Entity<SalesDetail>(entity =>
            {
                entity.HasKey(e => e.IdSalesD)
                    .HasName("PK__SalesDet__5A6D5566B46075CF");

                entity.ToTable("SalesDetail");

                entity.Property(e => e.Amount).HasColumnType("numeric(9, 2)");

                entity.Property(e => e.UnitPrice).HasColumnType("numeric(9, 2)");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.SalesDetails)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk2");

                entity.HasOne(d => d.IdSaleNavigation)
                    .WithMany(p => p.SalesDetails)
                    .HasForeignKey(d => d.IdSale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk0");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdUser).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
