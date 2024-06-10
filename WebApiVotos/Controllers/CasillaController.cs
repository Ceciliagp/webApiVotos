using Dominio.Modelos;
using Infraestructura.Plataforma;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Negocio.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApiVotos.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CasillaController : ControllerBase
    {
        private readonly ILogger<CasillaController> _logger;
        INServicioCasillas _casilla;

        public CasillaController(ILogger<CasillaController> logger, INServicioCasillas _casilla)
        {
            _logger = logger;
            this._casilla = _casilla;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<List<MCasilla>>> GetCasillas()
        {
            try
            {
                var respuesta = await _casilla.GetAllsCasillas();

                if (respuesta.EsError)
                    return new Response().GetRespuesta<List<MCasilla>>(respuesta.Mensaje);

                return new Response().GetRespuesta<List<MCasilla>>(respuesta.Contenido);
            }
            catch (Exception e)
            {
                return new Response().GetRespuesta<List<MCasilla>>("Error Excepción: " + e.Message);
            }
        }

        [HttpGet("consultaId")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<MCasilla>> GetCasillaxId(int id)
        {
            try
            {
                var respuesta = await _casilla.GetCasilla(id);

                if (respuesta.EsError)
                    return new Response().GetRespuesta<MCasilla>(respuesta.Mensaje);

                return new Response().GetRespuesta<MCasilla>(respuesta.Contenido);
            }
            catch (Exception e)
            {
                return new Response().GetRespuesta<MCasilla>("Error Excepción: " + e.Message);
            }
        }

        [HttpGet("consultaUsuario")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<List<MCasilla>>> GetCasillaxUsuario(int idUsuario)
        {
            try
            {
                var respuesta = await _casilla.GetCasillaxUsuario(idUsuario);

                if (respuesta.EsError)
                    return new Response().GetRespuesta<List<MCasilla>>(respuesta.Mensaje);

                return new Response().GetRespuesta<List<MCasilla>>(respuesta.Contenido);
            }
            catch (Exception e)
            {
                return new Response().GetRespuesta<List<MCasilla>>("Error Excepción: " + e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<Respuesta>> PostCasilla([FromBody] MCasilla Casilla)
        {
            try
            {
                var respuesta = await _casilla.PostCasilla(Casilla);

                if (respuesta.EsError)
                    return new Response().GetRespuesta<Respuesta>(respuesta.Mensaje);

                return new Response().GetRespuesta<Respuesta>(respuesta);
            }
            catch (Exception e)
            {
                return new Response().GetRespuesta<Respuesta>("Error Excepción: " + e.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<Respuesta>> PutCasilla([FromBody] MCasilla Casilla)
        {
            try
            {
                var respuesta = await _casilla.UpdateCasilla(Casilla);

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
        public async Task<RespuestaApi<Respuesta>> DeleteCasilla(int id)
        {
            try
            {
                var respuesta = await _casilla.DeleteCasilla(id);

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
