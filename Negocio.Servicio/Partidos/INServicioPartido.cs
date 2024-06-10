using Dominio.Entidades;
using Dominio.Modelos;
using Infraestructura.Plataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicio.Partidos
{
    public interface INServicioPartido
    {
        Task<Respuesta<List<MPartido>>> GetPartidos();
        Task<Respuesta<MPartido>> GetPartido(int id);
        Task<Respuesta> DeletePartido(int id);
        Task<Respuesta> PostPartido(MPartido partido);
        Task<Respuesta> UpdatePartido(MPartido partido);
    }
}
