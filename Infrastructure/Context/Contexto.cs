using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Associado> Associado { get; set; }
        public DbSet<Conveniado> Conveniado { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<TipoAtendimento> TipoAtendimento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            //Agendamento
            modelBuilder.Entity<Agendamento>()
              .HasKey(p => new { p.Id });

            modelBuilder.Entity<Agendamento>()
               .Property(r => r.Id)
               .ValueGeneratedOnAdd();

            //Associado
            modelBuilder.Entity<Associado>()
               .HasKey(p => new { p.Id });

            //modelBuilder.Entity<Associado>()
            //   .Property(r => r.Seql_Associado)
            //   .ValueGeneratedOnAdd();

            modelBuilder.Entity<Agendamento>()
               .HasOne(a => a.Associado)
               .WithMany()
               .HasForeignKey(p => p.AssociadoId);

            //Conveniado
            modelBuilder.Entity<Conveniado>()
               .HasKey(p => new { p.Id });

            //modelBuilder.Entity<Conveniado>()
            //   .Property(r => r.Seql_Conveniado)
            //   .ValueGeneratedOnAdd();

            modelBuilder.Entity<Agendamento>()
               .HasOne(a => a.Conveniado)
               .WithMany()
               .HasForeignKey(p => p.ConveniadoId);

            //Endereco
            modelBuilder.Entity<Endereco>()
               .HasKey(p => new { p.Id });

            //modelBuilder.Entity<Endereco>()
            //   .Property(r => r.Seql_Endereco)
            //   .ValueGeneratedOnAdd();

            modelBuilder.Entity<Agendamento>()
               .HasOne(a => a.Endereco)
               .WithMany()
               .HasForeignKey(p => p.EnderecoId);

            //Defaults
            modelBuilder.Entity<Agendamento>()
               .Property(a => a.DataAgendamento)
               .HasDefaultValueSql("getdate()");

            //TipoAtendimento
            modelBuilder.Entity<TipoAtendimento>()
               .HasKey(p => new { p.Id });

            modelBuilder.Entity<Agendamento>()
               .HasOne(a => a.TipoAtendimento)
               .WithMany()
               .HasForeignKey(p => p.TipoAtendimentoId);

            //Defaults
            modelBuilder.Entity<Agendamento>()
               .Property(a => a.DataAgendamento)
               .HasDefaultValueSql("getdate()");

            //Conversões
            //var converter = new EnumToNumberConverter<eTipoAtendimento, int>();

            //modelBuilder
            //   .Entity<Agendamento>()
            //   .Property(e => e.Cod_TipoAtendimento)
            //   .HasConversion(converter);

            base.OnModelCreating(modelBuilder);
        }
    }
}
