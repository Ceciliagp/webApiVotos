using Dominio.Modelos;
using Infraestructura.Plataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicio
{
    public interface INServicioVoto
    {
        Task<Respuesta<bool>> VerificarAccionVotar(int idVotante);
        Task<Respuesta> PostEjecerVoto(MVotos voto);
    }
}
