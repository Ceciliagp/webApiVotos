using Dominio.Modelos;
using Infraestructura.Plataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicios
{
    public interface IServicioVotante
    {
        Respuesta VerificarCredenciales(string curp, string seccion);
        Respuesta<MVotante> VerificarVotante(MVotante votantebd, MCasilla mCasilla, string seccion);
    }
}
