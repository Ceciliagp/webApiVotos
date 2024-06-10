using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Plataforma
{
    public class Respuesta<TResult>
    {
        public string Mensaje { get; set; }
        public TResult Contenido { get; set; }

        public Respuesta(TResult Contenido)
        {
            this.Contenido = Contenido;
            this.Mensaje = null;
        }

        public Respuesta(string Mensaje)
        {
            this.Mensaje = Mensaje;
        }

        public bool EsExito
        {
            get
            {
                return this.Mensaje == null;
            }
        }
        public bool EsError
        {
            get
            {
                return this.Mensaje != null;
            }
        }
    }

    public class Respuesta
    {
        public string Mensaje { get; set; }

        public Respuesta()
        {
            Mensaje = null;
        }

        public Respuesta(string mensaje)
        {
            Mensaje = mensaje;
        }

        public bool EsExito
        {
            get
            {
                return Mensaje == null;
            }
        }
        public bool EsError
        {
            get
            {
                return Mensaje != null;
            }
        }
    }
}
