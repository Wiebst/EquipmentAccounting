using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<EquipmentHistory> EquipmentHistory { get; set; }
        public DbSet<SoftwareLicense> SoftwareLicenses { get; set; }
        public DbSet<InstalledSoftware> InstalledSoftwares { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["EquipmentDb"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InstalledSoftware>()
                .HasKey(isw => new { isw.EquipmentId, isw.SoftwareLicenseId });

            modelBuilder.Entity<Equipment>()
                .HasIndex(e => e.InventoryNumber)
                .IsUnique();
        }
    }
}
