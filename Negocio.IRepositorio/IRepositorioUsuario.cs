using Dominio.Entidades;
using Dominio.Modelos;
using Infraestructura.Plataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IRepositorio
{
    public interface IRepositorioUsuario
    {
        Task<Respuesta<List<MUsuario>>> GetUsuarios();
        Task<Respuesta> UsuarioDuplicado(string nombre, int id);
        Task<Respuesta> SaveUsuario(Usuario Usuario);
        Task<Respuesta<MUsuario>> GetUsuarioxId(int id);
        Task<Respuesta<MUsuario>> GetUsuarioxUserPass(string user, string password);
        Task<Respuesta> UpdateUsuario(Usuario Usuario);
        Task<Respuesta> DeleteUsuario(Usuario Usuario);
    }
}
