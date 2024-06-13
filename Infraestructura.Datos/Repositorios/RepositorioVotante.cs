using Dominio.Entidades;
using Dominio.Modelos;
using Infraestructura.Extensiones;
using Infraestructura.Plataforma;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Negocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Datos.Repositorios
{
    public class RepositorioVotante: IRepositorioVotante
    {
        private readonly string TAG = "Votantes";
        private readonly DBContext _dbContext;

        public RepositorioVotante(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Respuesta<bool>> ExiteVotantexId(int id)
        {
            try
            {
                return new Respuesta<bool>(await _dbContext.Votante.AnyAsync(e => e.Activo && e.Id == id));
            }
            catch (Exception ex)
            {
                return new Respuesta<bool>(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }

        public async Task<Respuesta<MVotante>> GetVotantexCurp(string curp)
        {
            try
            {
                var votante = await _dbContext.Votante
                                     .Where(e => e.Activo && e.Curp == curp.Trim().ToUpper())
                                     .Select(p => new MVotante
                                     {
                                         Id = p.Id,
                                         Seccion = p.Seccion,
                                         Curp = p.Curp,
                                         Activo = p.Activo
                                     })
                                     .FirstOrDefaultAsync();

                return new Respuesta<MVotante>(votante);
            }
            catch (Exception ex)
            {
                return new Respuesta<MVotante>(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }

        public async Task<Respuesta<MVotante>> PostVotante(string curp, string seccion)
        {
            try
            {
                var votante = new Votante()
                {
                    Activo = true,
                    ClaveLector = string.Empty,
                    Curp = curp.Trim().ToUpper(), 
                    Seccion = seccion,
                    Id = 0
                };

                EntityEntry<Votante> entityVotante = await _dbContext.Votante.AddAsync(votante);
                await _dbContext.SaveChangesAsync();

                return new Respuesta<MVotante>(votante.MapClass<Votante, MVotante>());
            }
            catch (Exception ex)
            {
                return new Respuesta<MVotante>(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }
    }
}
