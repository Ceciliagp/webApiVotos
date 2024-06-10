using Dominio.Entidades;
using Dominio.Modelos;
using Infraestructura.Plataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicios
{
    public interface IServicioCasillas
    {
        Respuesta<Casilla> VerificarCasilla(MCasilla casilla);
        Respuesta<Casilla> EliminarCasilla(MCasilla Casilla);
    }
}
