using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Configurations;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext()
        {

        }

        public HospitalDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Visitation> Visitations { get; set; } = null!;
        public DbSet<Diagnose> Diagnoses { get; set; } = null!;
        public DbSet<Medicament> Medicaments { get; set; } = null!;
        public DbSet<PatientMedicament> Prescriptions { get; set; } = null!;
        public DbSet<Doctor> Doctors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ServerConfiguration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Defining complex key for Prescriptions
            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(pk => new { pk.PatientId, pk.MedicamentId });
            });

            modelBuilder.ApplyConfiguration(new VisitationConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new DiagnoseConfiguration());
        }
    }
}