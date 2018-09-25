using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApartmentsAllocationHelper.Models.EntityModels
{
    public partial class ApartmentDeliveryDbContext : DbContext
    {
        public ApartmentDeliveryDbContext()
        {
        }

        public ApartmentDeliveryDbContext(DbContextOptions<ApartmentDeliveryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apartments> Apartments { get; set; }
        public virtual DbSet<ApartmentTypesPerTower> ApartmentTypesPerTower { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Floors> Floors { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Towers> Towers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApartmentDeliveryDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartments>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ApartmentName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ApartmentNumber).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.ClientId)
                    .HasColumnName("ClientID")
                    .HasMaxLength(50);

                entity.Property(e => e.FloorId)
                    .IsRequired()
                    .HasColumnName("FloorID")
                    .HasMaxLength(50);

                entity.Property(e => e.OccupationDate).HasColumnType("datetime");

                entity.Property(e => e.OccupationStatus)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TypeId)
                    .IsRequired()
                    .HasColumnName("TypeID")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("Apartments_fk1");

                entity.HasOne(d => d.Floor)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.FloorId)
                    .HasConstraintName("Apartments_fk2");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("Apartments_fk0");
            });

            modelBuilder.Entity<ApartmentTypesPerTower>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ApartmentArea).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.ApartmentImage).HasColumnType("image");

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.TagNumber).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.TowerId)
                    .IsRequired()
                    .HasColumnName("TowerID")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Tower)
                    .WithMany(p => p.ApartmentTypesPerTower)
                    .HasForeignKey(d => d.TowerId)
                    .HasConstraintName("ApartmentTypesPerTower_fk0");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientAddress).HasMaxLength(500);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.NationalId)
                    .IsRequired()
                    .HasColumnName("NationalID")
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Floors>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ApartmentsNumber).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.FloorNo).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.TowerId)
                    .IsRequired()
                    .HasColumnName("TowerID")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Tower)
                    .WithMany(p => p.Floors)
                    .HasForeignKey(d => d.TowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Floors_fk0");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasIndex(e => e.ProjectName)
                    .HasName("UQ__Projects__0BBE213867902950")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasColumnName("Project_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Towers>(entity =>
            {
                entity.HasIndex(e => e.TowerName)
                    .HasName("UQ__Towers__D8B98684258E39BE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ApartmentsPerFloor).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.FloorsNumber).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.ProjectId)
                    .IsRequired()
                    .HasColumnName("ProjectID")
                    .HasMaxLength(50);

                entity.Property(e => e.TowerImage).HasColumnType("image");

                entity.Property(e => e.TowerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Towers)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("Towers_fk0");
            });
        }
    }
}
