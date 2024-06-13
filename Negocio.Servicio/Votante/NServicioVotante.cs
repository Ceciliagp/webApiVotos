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
    public class NServicioVotante : INServicioVotante
    {
        IRepositorioVotante repositorio;
        IServicioVotante servicio;
        INServicioVoto negVoto;
        INServicioCasillas negCasilla;

        public NServicioVotante(IRepositorioVotante repositorio, IServicioVotante servicio, INServicioVoto negVoto, INServicioCasillas negCasilla)
        {
            this.repositorio = repositorio;
            this.servicio = servicio;
            this.negVoto = negVoto;
            this.negCasilla = negCasilla;
        }

        public async Task<Respuesta<MVotante>> GetVerificacionVotante(string curp, string seccion)
        {
            var verificacion = servicio.VerificarCredenciales(curp, seccion);

            if (verificacion.EsError) return new Respuesta<MVotante>(verificacion.Mensaje);

            var votanteBD = await repositorio.GetVotantexCurp(curp);

            if (votanteBD.EsError) return new Respuesta<MVotante>(votanteBD.Mensaje);

            MVotante modelo = null;

            if (Extension.esNuloOVacio(votanteBD.Contenido))
            {
                var saveNuevo = await repositorio.PostVotante(curp, seccion);

                if(saveNuevo.EsError) return new Respuesta<MVotante>(saveNuevo.Mensaje);

                modelo = saveNuevo.Contenido;
            }
            else
            {
                modelo = votanteBD.Contenido;
            }

            var votoRealizado = await negVoto.VerificarAccionVotar(modelo.Id);

            if(votoRealizado.EsError) return new Respuesta<MVotante>(votoRealizado.Mensaje);

            if (votoRealizado.Contenido) return new Respuesta<MVotante>($"El ciudadano con Curp '{curp}' ya realizo su Voto.");

            var casilla = await negCasilla.GetCasillaxSeccion(modelo.Seccion);

            if(casilla.EsError) return new Respuesta<MVotante>(casilla.Mensaje);

            return servicio.VerificarVotante(modelo, casilla.Contenido, seccion);
        }

        public async Task<Respuesta> PostEjecerVoto(MVotos voto)
        {
            var votanteBD = await repositorio.ExiteVotantexId(voto.IdVotante);

            if (votanteBD.EsError) return new Respuesta(votanteBD.Mensaje);

            if(!(votanteBD?.Contenido ?? false)) return new Respuesta("Ha ocurrido un Error al verificar al Ciudadano.");

            var casilla = await negCasilla.GetCasillaxSeccion(voto.Seccion);

            if (casilla.EsError) return new Respuesta(casilla.Mensaje);

            var fechaActual = DateTime.Now;

            if (fechaActual.Date < casilla.Contenido.FechaInicio.Date) return new Respuesta($"La Casilla con Sección '{voto.Seccion}' no ha sido Aperturada hasta las {casilla.Contenido.FechaInicio}. \nComuniquese con el funcionario respectivo.");
            if (fechaActual.Date > casilla.Contenido.FechaFin.Date) return new Respuesta($"La Casilla con Sección '{voto.Seccion}' ya fue cerrada desde las {casilla.Contenido.FechaFin}.");

            return await negVoto.PostEjecerVoto(voto);
        }
    }
}
