using Microsoft.EntityFrameworkCore;
using WebApiKalum.Entities;

namespace WebApiKalum
{
    public class KalumDbContext : DbContext
    {

        public DbSet<CarreraTecnica> CarreraTecnica{get; set;}

        public DbSet<Jornada> Jornada{get; set;}
        public DbSet<ExamenAdmision> ExamenAdmision{get; set;}
        public DbSet<Aspirante> Aspirante{get; set;}
        public DbSet<Inscripcion> Inscripcion{get; set;}
        public DbSet<Alumno> Alumno{get; set;}
        public DbSet<Cargo> Cargo{get; set;}
        public KalumDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarreraTecnica>().ToTable("CarreraTecnica").HasKey(ct => new {ct.CarreraId});
            modelBuilder.Entity<Jornada>().ToTable("Jornada").HasKey(j => new {j.JornadaId});
            modelBuilder.Entity<ExamenAdmision>().ToTable("ExamenAdmision").HasKey(ea => new {ea.ExamenId});
            modelBuilder.Entity<Aspirante>().ToTable("Aspirante").HasKey(a => new {a.NoExpediente});
            modelBuilder.Entity<Inscripcion>().ToTable("Inscripcion").HasKey(i => new {i.InscripcionId});
            modelBuilder.Entity<Alumno>().ToTable("Alumno").HasKey(al => new {al.Carne});
            modelBuilder.Entity<Cargo>().ToTable("Cargo").HasKey(ca => new {ca.CargoId});
           
            modelBuilder.Entity<Aspirante>()
                .HasOne<CarreraTecnica>(a => a.CarreraTecnica)
                .WithMany(ct =>ct.Aspirantes)
                .HasForeignKey(a => a.CarreraId);
            
            modelBuilder.Entity<Aspirante>()
                .HasOne<Jornada>(a => a.Jornada)
                .WithMany(j =>j.Aspirantes)
                .HasForeignKey(a => a.JornadaId);

            modelBuilder.Entity<Aspirante>()
                .HasOne<ExamenAdmision>(a => a.ExamenAdmision)
                .WithMany(ea =>ea.Aspirantes)
                .HasForeignKey(a => a.ExamenId);

                
            modelBuilder.Entity<Inscripcion>()
                .HasOne<CarreraTecnica>(i => i.CarreraTecnica)
                .WithMany(ct =>ct.Inscripciones)
                .HasForeignKey(i => i.InscripcionId);

            modelBuilder.Entity<Inscripcion>()
                .HasOne<Jornada>(i => i.Jornada)
                .WithMany(j =>j.Inscripciones)
                .HasForeignKey(i => i.JornadaId);

            modelBuilder.Entity<Inscripcion>()
                .HasOne<Alumno>(i => i.Alumno)
                .WithMany(al =>al.Inscripciones)
                .HasForeignKey(i => i.Carne);
        }
        
    }
}