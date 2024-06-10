using Dominio.Entidades;
using Dominio.Modelos;
using Infraestructura.Plataforma;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Negocio.Servicio.Partidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApiVotos.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartidosController : ControllerBase
    {
        private readonly ILogger<PartidosController> _logger;

        INServicioPartido _partido;

        public PartidosController(ILogger<PartidosController> logger, INServicioPartido partido)
        {
            _logger = logger;
            _partido = partido;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<List<MPartido>>> GetPartidos()
        {
            try
            {
                var respuesta = await _partido.GetPartidos();

                if (respuesta.EsError)
                    return new Response().GetRespuesta<List<MPartido>>(respuesta.Mensaje);

                return new Response().GetRespuesta<List<MPartido>>(respuesta.Contenido);
            }
            catch (Exception e)
            {
                return new Response().GetRespuesta<List<MPartido>>("Error Excepción: " + e.Message);
            }
        }

        [HttpGet("consulta")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<MPartido>> GetPartido(int id)
        {
            try
            {
                var respuesta = await _partido.GetPartido(id);

                if (respuesta.EsError)
                    return new Response().GetRespuesta<MPartido>(respuesta.Mensaje);

                return new Response().GetRespuesta<MPartido>(respuesta.Contenido);
            }
            catch (Exception e)
            {
                return new Response().GetRespuesta<MPartido>("Error Excepción: " + e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<Respuesta>> PostPartido([FromBody] MPartido partido)
        {
            try
            {
                var respuesta = await _partido.PostPartido(partido);

                if (respuesta.EsError)
                    return new Response().GetRespuesta <Respuesta> (respuesta.Mensaje);

                return new Response().GetRespuesta<Respuesta>(respuesta);
            }
            catch (Exception e)
            {
                return new Response().GetRespuesta<Respuesta>("Error Excepción: " + e.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<Respuesta>> PutPartido([FromBody] MPartido partido)
        {
            try
            {
                var respuesta = await _partido.UpdatePartido(partido);

                if (respuesta.EsError)
                    return new Response().GetRespuesta<Respuesta>(respuesta.Mensaje);

                return new Response().GetRespuesta<Respuesta>(respuesta);
            }
            catch (Exception e)
            {
                return new Response().GetRespuesta<Respuesta>("Error Excepción: " + e.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<Respuesta>> DeletePartido(int id)
        {
            try
            {
                var respuesta = await _partido.DeletePartido(id);

                if (respuesta.EsError)
                    return new Response().GetRespuesta<Respuesta>(respuesta.Mensaje);

                return new Response().GetRespuesta<Respuesta>(respuesta);
            }
            catch (Exception e)
            {
                return new Response().GetRespuesta<Respuesta>("Error Excepción: " + e.Message);
            }
        }
    }

}
