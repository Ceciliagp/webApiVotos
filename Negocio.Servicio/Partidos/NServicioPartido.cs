using Dominio.Entidades;
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

namespace Negocio.Servicio.Partidos
{
    public class NServicioPartido : INServicioPartido
    {
        IRepositorioPartidos repositorio;
        IServicioPartido servicio;

        public NServicioPartido(IRepositorioPartidos repositorio, IServicioPartido servicio)
        {
            this.repositorio = repositorio;
            this.servicio = servicio;
        }

        public async Task<Respuesta> DeletePartido(int id)
        {
            var partidoBd = await this.GetPartido(id);

            if (partidoBd.EsError) return new Respuesta(partidoBd.Mensaje);

            var validacion = servicio.EliminarPartido(partidoBd.Contenido);

            if (validacion.EsError) return new Respuesta(validacion.Mensaje);

            var save = await repositorio.DeletePartido(validacion.Contenido);

            if (save.EsError) return new Respuesta(save.Mensaje);

            return new Respuesta();
        }

        public Task<Respuesta<MPartido>> GetPartido(int id)
        {
            return repositorio.GetPartidoxId(id);
        }

        public async Task<Respuesta<List<MPartido>>> GetPartidos()
        {
            return await repositorio.GetPartidos();
        }

        public async Task<Respuesta> PostPartido(MPartido partido)
        {
            var validacion = servicio.VerificarPartido(partido);

            if (validacion.EsError) return new Respuesta(validacion.Mensaje);

            var repetido = await repositorio.PartidoDuplicado(partido.Nombre, partido.Id);

            if (repetido.EsError) return new Respuesta(repetido.Mensaje);

            var save = await repositorio.SavePartido(validacion.Contenido);

            if (save.EsError) return new Respuesta(save.Mensaje);

            return new Respuesta();
        }

        public async Task<Respuesta> UpdatePartido(MPartido partido)
        {
            if (Extension.esNuloOVacio(partido)) return new Respuesta("El Partido no es Valido.");

            var repetido = await repositorio.PartidoDuplicado(partido.Nombre, partido.Id);

            if (repetido.EsError) return new Respuesta(repetido.Mensaje);

            var partidoBD = await repositorio.GetPartidoxId(partido.Id);

            if (partidoBD.EsError) return new Respuesta(partidoBD.Mensaje);

            var validacion = servicio.VerificarPartido(partido, partidoBD.Contenido);

            if (validacion.EsError) return new Respuesta(validacion.Mensaje);

            var save = await repositorio.UpdatePartido(validacion.Contenido);

            if (save.EsError) return new Respuesta(save.Mensaje);

            return new Respuesta();
        }
    }
}
