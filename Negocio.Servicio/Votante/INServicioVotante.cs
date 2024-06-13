using Dominio.Modelos;
using Infraestructura.Plataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicio
{
    public interface INServicioVotante
    {
        Task<Respuesta<MVotante>> GetVerificacionVotante(string curp, string seccion);
        Task<Respuesta> PostEjecerVoto(MVotos voto);
    }
}
