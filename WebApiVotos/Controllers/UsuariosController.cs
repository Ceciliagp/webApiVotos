using Dominio.Modelos;
using Infraestructura.Plataforma;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Negocio.Servicio;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace WebApiVotos.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;

        INServicioUsuario _user;

        public UsuariosController(ILogger<UsuariosController> logger, INServicioUsuario _user)
        {
            _logger = logger;
            this._user = _user;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<List<MUsuario>>> GetUsuarios()
        {
            try
            {
                var respuesta = await _user.GetUsuarios();

                if (respuesta.EsError)
                    return new Response().GetRespuesta<List<MUsuario>>(respuesta.Mensaje);

                return new Response().GetRespuesta<List<MUsuario>>(respuesta.Contenido);
            }
            catch (Exception e)
            {
                return new Response().GetRespuesta<List<MUsuario>>("Error Excepción: " + e.Message);
            }
        }
        
        [HttpGet("consulta")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<MUsuario>> GetUsuario(int id)
        {
            try
            {
                var respuesta = await _user.GetUsuario(id);

                if (respuesta.EsError)
                    return new Response().GetRespuesta<MUsuario>(respuesta.Mensaje);

                return new Response().GetRespuesta<MUsuario>(respuesta.Contenido);
            }
            catch (Exception e)
            {
                return new Response().GetRespuesta<MUsuario>("Error Excepción: " + e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<Respuesta>> PostUsuario([FromBody] MUsuario usuario)
        {
            try
            {
                var respuesta = await _user.PostUsuario(usuario);

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
        public async Task<RespuestaApi<Respuesta>> PutUsuario([FromBody] MUsuario usuario)
        {
            try
            {
                var respuesta = await _user.UpdateUsuario(usuario);

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
        public async Task<RespuestaApi<Respuesta>> DeleteUsuario(int id)
        {
            try
            {
                var respuesta = await _user.DeleteUsuario(id);

                if (respuesta.EsError)
                    return new Response().GetRespuesta<Respuesta>(respuesta.Mensaje);

                return new Response().GetRespuesta<Respuesta>(respuesta);
            }
            catch (Exception e)
            {
                return new Response().GetRespuesta<Respuesta>("Error Excepción: " + e.Message);
            }
        }

        [HttpPost("verificacion")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<MUsuario>> PostLogin([FromBody] MUsuario usuario)
        {
            try
            {
                var respuesta = await _user.PostLogin(usuario);

                if (respuesta.EsError)
                    return new Response().GetRespuesta<MUsuario>(respuesta.Mensaje);

                return new Response().GetRespuesta<MUsuario>(respuesta.Contenido);
            }
            catch (Exception e)
            {
                return new Response().GetRespuesta<MUsuario>("Error Excepción: " + e.Message);
            }
        }
    }
}