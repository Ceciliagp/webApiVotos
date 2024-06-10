using Dominio.Modelos;
using Dominio.Servicios;
using Infraestructura.Extensiones;
using Infraestructura.Plataforma;
using Negocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicio
{
    public class NServicioCasillas : INServicioCasillas
    {
        IRepositorioCasillas repositorio;
        IServicioCasillas servicio;
        INServicioUsuario serUser;

        public NServicioCasillas(IRepositorioCasillas repositorio, IServicioCasillas servicio, INServicioUsuario serUser)
        {
            this.repositorio = repositorio;
            this.servicio = servicio;
            this.serUser = serUser;
        }

        public async Task<Respuesta> DeleteCasilla(int id)
        {
            var CasillaBd = await this.GetCasilla(id);

            if (CasillaBd.EsError) return new Respuesta(CasillaBd.Mensaje);

            var user = await serUser.GetUsuario(CasillaBd.Contenido.IdUsuario ?? 0);

            if (user.EsError) return new Respuesta(user.Mensaje);

            var validacion = servicio.EliminarCasilla(CasillaBd.Contenido);

            if (validacion.EsError) return new Respuesta(validacion.Mensaje);

            var save = await repositorio.DeleteCasilla(validacion.Contenido);

            if (save.EsError) return new Respuesta(save.Mensaje);

            return new Respuesta();
        }

        public async Task<Respuesta<List<MCasilla>>> GetAllsCasillas()
        {
            return await repositorio.GetAllCasillas();
        }

        public async Task<Respuesta<MCasilla>> GetCasilla(int id)
        {
            return await repositorio.GetCasillaxId(id);
        }

        public async Task<Respuesta<List<MCasilla>>> GetCasillaxUsuario(int idUsuario)
        {
            var user = await serUser.GetUsuario(idUsuario);

            if (user.EsError) return new Respuesta<List<MCasilla>>(user.Mensaje);

            return await repositorio.GetCasillasxUsuario(idUsuario);
        }

        public async Task<Respuesta> PostCasilla(MCasilla casilla)
        {
            var validacion = servicio.VerificarCasilla(casilla);

            if (validacion.EsError) return new Respuesta(validacion.Mensaje);

            var user = await serUser.GetUsuario(casilla.IdUsuario ?? 0);

            if(user.EsError) return new Respuesta(user.Mensaje);

            var repetido = await repositorio.CasillaDuplicada(casilla.Seccion, casilla.Id);

            if (repetido.EsError) return new Respuesta(repetido.Mensaje);

            var save = await repositorio.SaveCasilla(validacion.Contenido);

            if (save.EsError) return new Respuesta(save.Mensaje);

            return new Respuesta();
        }

        public async Task<Respuesta> UpdateCasilla(MCasilla casilla)
        {
            if (Extension.esNuloOVacio(casilla)) return new Respuesta("La Casilla no es Valida.");

            var repetido = await repositorio.CasillaDuplicada(casilla.Seccion, casilla.Id);

            if (repetido.EsError) return new Respuesta(repetido.Mensaje);

            var user = await serUser.GetUsuario(casilla.IdUsuario ?? 0);

            if (user.EsError) return new Respuesta(user.Mensaje);

            var partidoBD = await repositorio.GetCasillaxId(casilla.Id);

            if (partidoBD.EsError) return new Respuesta(partidoBD.Mensaje);

            var validacion = servicio.VerificarCasilla(casilla);

            if (validacion.EsError) return new Respuesta(validacion.Mensaje);

            var save = await repositorio.UpdateCasilla(validacion.Contenido);

            if (save.EsError) return new Respuesta(save.Mensaje);

            return new Respuesta();
        }
    }
}
