using Dominio.Entidades;
using Dominio.Modelos;
using Infraestructura.Extensiones;
using Infraestructura.Plataforma;
using Microsoft.EntityFrameworkCore;
using Negocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Datos.Repositorios
{
    public class RepositorioCasillas : IRepositorioCasillas
    {
        private readonly string TAG = "Casillas";
        private readonly DBContext _dbContext;

        public RepositorioCasillas(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Respuesta> CasillaDuplicada(string seccion, int IdCasilla)
        {
            try
            {
                if (await _dbContext.Casilla.AnyAsync(e => e.Seccion.Equals(seccion) && e.Activo && e.Id != IdCasilla)) return new Respuesta("La Casilla ya se encuentra registrada.");

                return new Respuesta();
            }
            catch (Exception ex)
            {
                return new Respuesta(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }

        public async Task<Respuesta> DeleteCasilla(Casilla casilla)
        {
            try
            {
                _dbContext.Casilla.Update(casilla);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Respuesta(String.Format(MsjAviso.ErrorDB, TAG));
            }

            return new Respuesta();
        }

        public async Task<Respuesta<List<MCasilla>>> GetAllCasillas()
        {
            try
            {
                var casillas = await _dbContext.Casilla.Where(e => e.Activo).Select(p => new MCasilla
                {
                    Id = p.Id,
                    Seccion = p.Seccion,
                    FechaFin = p.FechaFin,
                    FechaInicio = p.FechaInicio,
                    IdUsuario = p.IdUsuario,
                    Activo = p.Activo,
                    Usuario = p.Usuario.MapClass<Usuario, MUsuario>()
                }).ToListAsync();

                return new Respuesta<List<MCasilla>>(casillas);
            }
            catch (Exception ex)
            {
                return new Respuesta<List<MCasilla>>(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }

        public async Task<Respuesta<List<MCasilla>>> GetCasillasxUsuario(int idUsuario)
        {
            try
            {
                var casillas = await _dbContext.Casilla.Where(e => e.Activo && e.IdUsuario == idUsuario).Select(p => new MCasilla
                {
                    Id = p.Id,
                    Seccion = p.Seccion,
                    FechaFin = p.FechaFin,
                    FechaInicio = p.FechaInicio,
                    IdUsuario = p.IdUsuario,
                    Activo = p.Activo
                }).ToListAsync();

                return new Respuesta<List<MCasilla>>(casillas);
            }
            catch (Exception ex)
            {
                return new Respuesta<List<MCasilla>>(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }

        public async Task<Respuesta<MCasilla>> GetCasillaxId(int id)
        {
            try
            {
                var casilla = await _dbContext.Casilla
                                     .Where(e => e.Activo && e.Id == id)
                                     .Select(p => new MCasilla
                                     {
                                         Id = p.Id,
                                         Seccion = p.Seccion,
                                         FechaFin = p.FechaFin,
                                         FechaInicio = p.FechaInicio,
                                         IdUsuario = p.IdUsuario,
                                         Activo = p.Activo
                                     })
                                     .FirstOrDefaultAsync();

                if(Extension.esNuloOVacio(casilla) || !(casilla?.Activo ?? false)) return new Respuesta<MCasilla>("La Casilla fue previamente eliminada.");

                return new Respuesta<MCasilla>(casilla);
            }
            catch (Exception ex)
            {
                return new Respuesta<MCasilla>(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }

        public async Task<Respuesta<MCasilla>> GetCasillaxSeccion(string seccion)
        {
            try
            {
                var casilla = await _dbContext.Casilla
                                     .Where(e => e.Activo && e.Seccion == seccion)
                                     .Select(p => new MCasilla
                                     {
                                         Id = p.Id,
                                         Seccion = p.Seccion,
                                         FechaFin = p.FechaFin,
                                         FechaInicio = p.FechaInicio,
                                         IdUsuario = p.IdUsuario,
                                         Activo = p.Activo
                                     })
                                     .FirstOrDefaultAsync();

                return new Respuesta<MCasilla>(casilla);
            }
            catch (Exception ex)
            {
                return new Respuesta<MCasilla>(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }

        public async Task<Respuesta> SaveCasilla(Casilla casilla)
        {
            try
            {
                await _dbContext.Casilla.AddAsync(casilla);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Respuesta(String.Format(MsjAviso.ErrorDB, TAG));
            }

            return new Respuesta();
        }

        public async Task<Respuesta> UpdateCasilla(Casilla casilla)
        {
            try
            {
                _dbContext.Casilla.Update(casilla);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Respuesta(String.Format(MsjAviso.ErrorDB, TAG));
            }

            return new Respuesta();
        }
    }
}
