using Dominio.Entidades;
using Dominio.Modelos;
using Infraestructura.Plataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicio
{
    public interface INServicioUsuario
    {
        Task<Respuesta<List<MUsuario>>> GetUsuarios();
        Task<Respuesta<MUsuario>> GetUsuario(int id);
        Task<Respuesta> DeleteUsuario(int id);
        Task<Respuesta> PostUsuario(MUsuario usuario);
        Task<Respuesta<MUsuario>> PostLogin(MUsuario usuario);
        Task<Respuesta> UpdateUsuario(MUsuario usuario);
    }
}
