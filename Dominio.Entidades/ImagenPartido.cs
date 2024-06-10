using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [Table("ImagenPartido")]
    public class ImagenPartido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public byte[] Data { get; set; } // Array de bytes para la imagen

        [Required]
        [MaxLength(45)]
        public string FileName { get; set; }

        [Required]
        [MaxLength(45)]
        public string ContentType { get; set; }

        public bool Activo { get; set; }

        [Required]
        public int IdPartido { get; set; }

        [ForeignKey("IdPartido")]
        public Partido Partido { get; set; }
    }
}
