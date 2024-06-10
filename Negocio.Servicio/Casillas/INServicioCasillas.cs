using Dominio.Modelos;
using Infraestructura.Plataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicio
{
    public interface INServicioCasillas
    {
        Task<Respuesta<List<MCasilla>>> GetAllsCasillas();
        Task<Respuesta<MCasilla>> GetCasilla(int id);
        Task<Respuesta<List<MCasilla>>> GetCasillaxUsuario(int idUsuario);
        Task<Respuesta> DeleteCasilla(int id);
        Task<Respuesta> PostCasilla(MCasilla casilla);
        Task<Respuesta> UpdateCasilla(MCasilla casilla);
    }
}
