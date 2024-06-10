using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Plataforma
{
    public class Response
    {
        public RespuestaApi<TContent> GetRespuesta<TContent>(TContent content, string mensaje = "")
        {
            var respuestaApi = new RespuestaApi<TContent>();
            respuestaApi.CONTENIDO = content;
            respuestaApi.EXITOSO = true;
            respuestaApi.RESPUESTA = mensaje;
            return respuestaApi;
        }

        public Response() { }

        public RespuestaApi<TContent> GetRespuesta<TContent>(string respuesta)
        {
            var respuestaApi = new RespuestaApi<TContent>(respuesta);

            return respuestaApi;
        }
    }

    public class RespuestaApi<TContent>
    {
        public bool EXITOSO { get; set; }
        public TContent CONTENIDO { get; set; }
        public string RESPUESTA { get; set; } = "";

        public RespuestaApi() { }

        public RespuestaApi(string message = "")
        {
            EXITOSO = false;
            RESPUESTA = message;
        }
    }
}
