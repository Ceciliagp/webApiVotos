using Dominio.Modelos;
using Infraestructura.Plataforma;
using Negocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicio
{
    public class NServicioVoto : INServicioVoto
    {
        IRepositorioVoto repositorio;

        public NServicioVoto(IRepositorioVoto repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Respuesta> PostEjecerVoto(MVotos voto)
        {
            return await repositorio.PostEjecerVoto(voto);
        }

        public async Task<Respuesta<bool>> VerificarAccionVotar(int idVotante)
        {
            return await repositorio.VerificarAccionVotar(idVotante);
        }
    }
}
