using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(45)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(45)]
        public string Apellido { get; set; }

        [Required]
        [MaxLength(45)]
        public string NombreUsuario { get; set; }

        [Required]
        [MaxLength(45)]
        public string Contrasenia { get; set; }

        [Required]
        [MaxLength(45)]
        public bool Activo { get; set; }

        [Required]
        public int IdRol { get; set; }

        [ForeignKey("IdRol")]
        public Roles Rol { get; set; }
    }
}
