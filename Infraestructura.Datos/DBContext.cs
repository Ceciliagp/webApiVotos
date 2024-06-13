using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Datos
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Propuesta>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<Usuario>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<Partido>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<Votante>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<Roles>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<ImagenPartido>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<Casilla>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<Votos>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
        }

        public DbSet<Propuesta> Propuestas { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Partido> Partido { get; set; }
        public DbSet<Votante> Votante { get; set; }
        public DbSet<Roles> Rol { get; set; }
        public DbSet<ImagenPartido> ImagenPartido { get; set; }
        public DbSet<Casilla> Casilla { get; set; }
        public DbSet<Votos> Voto { get; set; }
    }
}
