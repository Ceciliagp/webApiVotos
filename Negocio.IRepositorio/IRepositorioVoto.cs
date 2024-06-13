using Dominio.Modelos;
using Infraestructura.Plataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IRepositorio
{
    public interface IRepositorioVoto
    {
        Task<Respuesta<bool>> VerificarAccionVotar(int idVotante);
        Task<Respuesta> PostEjecerVoto(MVotos voto);
    }
}
