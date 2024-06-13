using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class MVotante
    {
        public int Id { get; set; }
        public string Curp { get; set; }
        public string ClaveLector { get; set; }
        public string Seccion { get; set; }
        public bool Activo { get; set; } = true;

        public MCasilla Casilla { get; set; }
    }
}
