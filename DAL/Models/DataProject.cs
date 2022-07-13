using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class DataProject : DbContext
    {
        public DataProject()
        {
        }

        public DataProject(DbContextOptions<DataProject> options)
            : base(options)
        {
        }

        public virtual DbSet<Collector> Collector { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<ProductGroups> ProductGroups { get; set; }
        public virtual DbSet<ProductModels> ProductModels { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsOnOrder> ProductsOnOrder { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(" Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin-c\\Desktop\\Project_shiraSaraMalul\\DateProject1.mdf;Integrated Security=True;Connect Timeout=30 ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collector>(entity =>
            {
                entity.HasKey(e => e.CodeCollector)
                    .HasName("PK__Collecto__667C1BD28F451E7E");

                entity.Property(e => e.CodeCollector).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.NameCollector)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Colors>(entity =>
            {
                entity.HasKey(e => e.CodeColor)
                    .HasName("PK__Colors__4AE422EB6C29BC15");

                entity.Property(e => e.NameColor)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.CodeOrder)
                    .HasName("PK__Orders__C2DFCF59E3A1384E");

                entity.Property(e => e.DateOrder).HasColumnType("datetime");

                entity.Property(e => e.ExecutionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductGroups>(entity =>
            {
                entity.HasKey(e => e.CodeGroups)
                    .HasName("PK__ProductG__1FA0148FFD328B4E");

                entity.Property(e => e.NaneGroups)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ProductModels>(entity =>
            {
                entity.HasKey(e => e.CodeModel)
                    .HasName("PK__ProductM__4A819BEAFCBF2678");

                entity.Property(e => e.CodeModel).ValueGeneratedNever();

                entity.HasOne(d => d.CodeColorNavigation)
                    .WithMany(p => p.ProductModels)
                    .HasForeignKey(d => d.CodeColor)
                    .HasConstraintName("FK_ProductModels_ToTable");

                entity.HasOne(d => d.CodeProductNavigation)
                    .WithMany(p => p.ProductModels)
                    .HasForeignKey(d => d.CodeProduct)
                    .HasConstraintName("FK_ProductModels_ToTable_1");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.CodeProduct)
                    .HasName("PK__Products__DD0D5D1613CD2672");

                entity.Property(e => e.NameProduct)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.CodeGroupNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CodeGroup)
                    .HasConstraintName("FK_Products_ToTable");

                entity.HasOne(d => d.CodeStorageNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CodeStorage)
                    .HasConstraintName("FK_Products_ToTable_1");
            });

            modelBuilder.Entity<ProductsOnOrder>(entity =>
            {
                entity.HasKey(e => e.CodeProductsOnOrder)
                    .HasName("PK__Products__20FC06DDC5FCDD10");

                entity.HasOne(d => d.CodeModelNavigation)
                    .WithMany(p => p.ProductsOnOrder)
                    .HasForeignKey(d => d.CodeModel)
                    .HasConstraintName("FK_ProductsOnOrder_ToTable_1");

                entity.HasOne(d => d.CodeOrderNavigation)
                    .WithMany(p => p.ProductsOnOrder)
                    .HasForeignKey(d => d.CodeOrder)
                    .HasConstraintName("FK_ProductsOnOrder_ToTable");
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasKey(e => e.CodeStorage)
                    .HasName("PK__Storage__C34C6E56A75482DD");

                entity.Property(e => e.NameStorage)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
