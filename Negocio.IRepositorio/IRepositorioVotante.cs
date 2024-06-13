using Dominio.Modelos;
using Infraestructura.Plataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IRepositorio
{
    public interface IRepositorioVotante
    {
        Task<Respuesta<MVotante>> GetVotantexCurp(string curp);
        Task<Respuesta<bool>> ExiteVotantexId(int id);
        Task<Respuesta<MVotante>> PostVotante(string curp, string seccion);
    }
}
