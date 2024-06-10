using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class MRol
    {
        public int Id { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; } = true;
    }
}
