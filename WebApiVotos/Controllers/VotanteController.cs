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
    public class VotanteController : ControllerBase
    {
        private readonly ILogger<VotanteController> _logger;
        INServicioVotante _votante;

        public VotanteController(ILogger<VotanteController> logger, INServicioVotante _votante)
        {
            _logger = logger;
            this._votante = _votante;
        }

        [HttpGet("verificacion")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<MVotante>> GetVerificacionVotante(string curp, string seccion)
        {
            try
            {
                var respuesta = await _votante.GetVerificacionVotante(curp, seccion);

                if (respuesta.EsError)
                    return new Response().GetRespuesta<MVotante>(respuesta.Mensaje);

                return new Response().GetRespuesta<MVotante>(respuesta.Contenido);
            }
            catch (Exception e)
            {
                return new Response().GetRespuesta<MVotante>("Error Excepción: " + e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<RespuestaApi<Respuesta>> PostEjecerVoto([FromBody] MVotos voto)
        {
            try
            {
                var respuesta = await _votante.PostEjecerVoto(voto);

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
