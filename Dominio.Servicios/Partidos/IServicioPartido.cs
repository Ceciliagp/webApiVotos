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
    public interface IServicioPartido
    {
        Respuesta<Partido> VerificarPartido(MPartido partido, MPartido partidoBD = null);
        Respuesta<Partido> EliminarPartido(MPartido partido);
    }
}
