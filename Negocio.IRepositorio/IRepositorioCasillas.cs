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
    public interface IRepositorioCasillas
    {
        Task<Respuesta<List<MCasilla>>> GetAllCasillas();
        Task<Respuesta> CasillaDuplicada(string seccion, int idPartido);
        Task<Respuesta> SaveCasilla(Casilla casilla);
        Task<Respuesta<MCasilla>> GetCasillaxId(int id);
        Task<Respuesta<MCasilla>> GetCasillaxSeccion(string seccion);
        Task<Respuesta<List<MCasilla>>> GetCasillasxUsuario(int idUsuario);
        Task<Respuesta> UpdateCasilla(Casilla casilla);
        Task<Respuesta> DeleteCasilla(Casilla casilla);
    }
}
