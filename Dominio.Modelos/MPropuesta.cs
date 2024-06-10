using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class MPropuesta
    {
        public int Id { get; set; }

        public string NombreCorto { get; set; }

        public string Descripcion { get; set; }

        public int IdPartido { get; set; }

        public bool Activo { get; set; }
    }
}
