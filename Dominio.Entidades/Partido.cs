using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [Table("Partido")]
    public class Partido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public ImagenPartido ImagenPartido { get; set; }

        public bool Activo { get; set; } = true;

        public string NombreCandidato { get; set; }

        public string ApellidoCandidato { get; set; }

        public List<Propuesta> Propuestas { get; set; }
    }
}
