using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class MImagenPartido
    {
        public int Id { get; set; }
        public byte[] Data { get; set; } 
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public bool Activo { get; set; }
        public int IdPartido { get; set; }
    }
}
