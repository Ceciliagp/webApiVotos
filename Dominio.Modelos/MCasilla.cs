using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class MCasilla
    {
        public int Id { get; set; }
        public string Seccion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Activo { get; set; }
        public int? IdUsuario { get; set; }

        public MUsuario Usuario { get; set; }
    }
}
