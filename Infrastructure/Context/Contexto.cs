using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
   public class Contexto : DbContext
   {
      public Contexto(DbContextOptions<Contexto> options) : base(options) { }

      public DbSet<Agendamento> Agendamento { get; set; }
      public DbSet<Associado> Associado { get; set; }
      public DbSet<Conveniado> Conveniado { get; set; }
      public DbSet<Endereco> Endereco { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Agendamento>()
           .HasKey(p => new { p.Seql_Agendamento });

         modelBuilder.Entity<Agendamento>()
            .Property(r => r.Seql_Agendamento)
            .ValueGeneratedOnAdd();

         modelBuilder.Entity<Associado>()
            .HasKey(p => new { p.Seql_Associado });

         modelBuilder.Entity<Associado>()
            .Property(r => r.Seql_Associado)
            .ValueGeneratedOnAdd();

         modelBuilder.Entity<Conveniado>()
            .HasKey(p => new { p.Seql_Conveniado });

         modelBuilder.Entity<Conveniado>()
            .Property(r => r.Seql_Conveniado)
            .ValueGeneratedOnAdd();

         modelBuilder.Entity<Endereco>()
            .HasKey(p => new { p.Seql_Endereco });

         modelBuilder.Entity<Endereco>()
            .Property(r => r.Seql_Endereco)
            .ValueGeneratedOnAdd();

         base.OnModelCreating(modelBuilder);
      }
   }
}
