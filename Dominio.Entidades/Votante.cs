using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [Table("Votante")]
    public class Votante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(18)]
        public string Curp { get; set; }

        [Required]
        [MaxLength(13)]
        public string ClaveLector { get; set; }

        [Required]
        [MaxLength(25)]
        public string Seccion { get; set; }

        [Required]
        public bool Activo { get; set; } = true;
    }
}
