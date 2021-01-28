using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CadastroCaminhao.Models
{
    public class CadastroCaminhaoContext : DbContext
    {
        public CadastroCaminhaoContext(DbContextOptions<CadastroCaminhaoContext> options) : base(options) { }
        public DbSet<Caminhao> Caminhao { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caminhao>(entity =>
            {
                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AnoFabricacao)
                    .IsRequired()
                    .HasColumnType("int");

                entity.Property(e => e.AnoModelo)
                    .IsRequired()
                    .HasColumnType("int");
            });

        }
    }
}
