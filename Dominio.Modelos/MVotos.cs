using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class MVotos
    {
        public int Id { get; set; }
        public int IdVotante { get; set; }
        public int IdPartido { get; set; }
        public DateTime FechaRegistro { get; set; }

        public string Seccion { get; set; }
    }
}
