using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [Table("Propuestas")]
    public class Propuesta
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Assuming Id is manually assigned
        public int Id { get; set; }

        public string NombreCorto { get; set; }

        public string Descripcion { get; set; }

        public int IdPartido { get; set; }

        public bool Activo { get; set; }

        [ForeignKey("IdPartido")]
        public Partido Partido { get; set; }
    }
}
