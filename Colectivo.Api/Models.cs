using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colectivo.Api.Models
{
    [Table("usuarios_login")]
    public class UsuarioLogin
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Usuario { get; set; } = string.Empty;
        [Required, MaxLength(200)]
        public string Contrasena { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? Rol { get; set; }
        [MaxLength(100)]
        public string? Territorio { get; set; }
    }

    [Table("miembros")]
    public class Miembro
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Nombre { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        [RegularExpression("^\\d{13}$", ErrorMessage = "El DNI debe tener exactamente 13 dígitos.")]
        public string Dni { get; set; } = string.Empty;
        [Column("fecha_nacimiento", TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        [MaxLength(50)]
        public string? Genero { get; set; }
        [MaxLength(50)]
        public string? Telefono { get; set; }
        [MaxLength(250)]
        public string? Direccion { get; set; }
        [Column("fecha_registro")]
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        [MaxLength(50)]
        public string? Rol { get; set; }
        public bool Activo { get; set; } = true;
        [MaxLength(100)]
        public string? Sector { get; set; }
        [MaxLength(150)]
        public string? ProfesionOficio { get; set; }
        public bool TrabajoMesas { get; set; } = false;
        public bool Empleado { get; set; } = false;
        public bool TrabajaraMesaGenerales2025 { get; set; } = false;
        [MaxLength(100)]
        public string? Territorio { get; set; }
    }

    public class ColectivoDbContext : DbContext
    {
        public ColectivoDbContext(DbContextOptions<ColectivoDbContext> options) : base(options) { }

        public DbSet<UsuarioLogin> UsuariosLogin { get; set; }
        public DbSet<Miembro> Miembros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioLogin>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Usuario).IsUnique();
                entity.Property(e => e.Usuario).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Contrasena).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Rol).HasMaxLength(50);
                entity.Property(e => e.Territorio).HasMaxLength(100);
            });

            modelBuilder.Entity<Miembro>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Dni).IsUnique();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Dni).IsRequired().HasMaxLength(20);
                entity.Property(e => e.FechaNacimiento).HasColumnType("date");
                entity.Property(e => e.Genero).HasMaxLength(50);
                entity.Property(e => e.Telefono).HasMaxLength(50);
                entity.Property(e => e.Direccion).HasMaxLength(250);
                entity.Property(e => e.FechaRegistro).HasDefaultValueSql("getutcdate()");
                entity.Property(e => e.Rol).HasMaxLength(50);
                entity.Property(e => e.Activo).HasDefaultValue(true);
                entity.Property(e => e.Sector).HasMaxLength(100);
                entity.Property(e => e.ProfesionOficio).HasMaxLength(150);
                entity.Property(e => e.TrabajoMesas).HasDefaultValue(false);
                entity.Property(e => e.Empleado).HasDefaultValue(false);
                entity.Property(e => e.TrabajaraMesaGenerales2025).HasDefaultValue(false);
                entity.Property(e => e.Territorio).HasMaxLength(100);
            });
        }
    }
}
