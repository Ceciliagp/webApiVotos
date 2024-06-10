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
    public interface IRepositorioPartidos
    {
        Task<Respuesta<List<MPartido>>> GetPartidos();
        Task<Respuesta> PartidoDuplicado(string nombre, int idPartido);
        Task<Respuesta> SavePartido(Partido partido);
        Task<Respuesta<MPartido>> GetPartidoxId(int id);
        Task<Respuesta> UpdatePartido(Partido partido);
        Task<Respuesta> DeletePartido(Partido partido);
    }
}
        
