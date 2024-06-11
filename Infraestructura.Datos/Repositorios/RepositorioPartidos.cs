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
    public class RepositorioPartidos: IRepositorioPartidos
    {
        private readonly string TAG = "Partidos";
        private readonly DBContext _dbContext;

        public RepositorioPartidos(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Respuesta<List<MPartido>>> GetPartidos()
        {
            try
            {
                var partidosConImagenes = await _dbContext.Partido.Where(e => e.Activo).Select(p => new MPartido
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    NombreCandidato = p.NombreCandidato,
                    ApellidoCandidato = p.ApellidoCandidato,
                    ImagenPartido = p.ImagenPartido.MapClass<ImagenPartido, MImagenPartido>(),
                    Propuestas = p.Propuestas.MapList<Propuesta, MPropuesta>()
                }).ToListAsync();

                return new Respuesta<List<MPartido>>(partidosConImagenes);
            }
            catch (Exception ex)
            {
                return new Respuesta<List<MPartido>>(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }

        public async Task<Respuesta<MPartido>> GetPartidoxId(int id)
        {
            try
            {
                var consulta = await _dbContext.Partido
                                 .Where(p => p.Id == id)
                                 .Select(p => new MPartido
                                 {
                                     Id = p.Id,
                                     Nombre = p.Nombre,
                                     Descripcion = p.Descripcion,
                                     NombreCandidato = p.NombreCandidato,
                                     ApellidoCandidato = p.ApellidoCandidato,
                                     Activo = p.Activo,
                                     Propuestas = p.Propuestas
                                         .Select(propuesta => new MPropuesta
                                         {
                                            // Mapear propiedades de Propuesta a MPropuesta
                                            Id = propuesta.Id,
                                             NombreCorto = propuesta.NombreCorto,
                                             Descripcion = propuesta.Descripcion,
                                             IdPartido = propuesta.IdPartido,
                                             Activo = propuesta.Activo
                                         }).Where(e => e.Activo).ToList(),
                                     ImagenPartido = Extension.esNuloOVacio(p.ImagenPartido) ? null : new MImagenPartido
                                     {
                                         // Mapear propiedades de ImagenPartido a MImagenPartido
                                         Id = p.ImagenPartido.Id,
                                         Data = p.ImagenPartido.Data,
                                         FileName = p.ImagenPartido.FileName,
                                         ContentType = p.ImagenPartido.ContentType,
                                         IdPartido = p.ImagenPartido.IdPartido
                                     }
                                 }).FirstOrDefaultAsync();


                if (Extension.esNuloOVacio(consulta) || !consulta.Activo) return new Respuesta<MPartido>("El Partido fue previamente eliminado.");

                return new Respuesta<MPartido>(consulta);
            }
            catch (Exception ex)
            {
                return new Respuesta<MPartido>(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }

        public async Task<Respuesta<MPartido>> GetEntPartidoxId(int id)
        {
            try
            {
                var consulta = await _dbContext.Partido
                                    .Where(p => p.Id == id)
                                    .Select(p => new MPartido
                                    {
                                        Id = p.Id,
                                        Nombre = p.Nombre,
                                        Descripcion = p.Descripcion,
                                        NombreCandidato = p.NombreCandidato,
                                        ApellidoCandidato = p.ApellidoCandidato,
                                        Activo = p.Activo,
                                        Propuestas = p.Propuestas.ToList().MapList<Propuesta, MPropuesta>(),
                                        ImagenPartido = p.ImagenPartido.MapClass<ImagenPartido, MImagenPartido>(),
                                    }).FirstOrDefaultAsync();

                if (Extension.esNuloOVacio(consulta) || !consulta.Activo) return new Respuesta<MPartido>("El Partido fue previamente eliminado.");

                return new Respuesta<MPartido>(consulta);
            }
            catch (Exception ex)
            {
                return new Respuesta<MPartido>(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }

        public async Task<Respuesta> PartidoDuplicado(string nombre, int idPartido)
        {
            try
            {
                if (await _dbContext.Partido.AnyAsync(e => e.Nombre.Equals(nombre) && e.Activo && e.Id != idPartido)) return new Respuesta("El Partido ya se encuentra registrado.");
               
                return new Respuesta();
            }
            catch (Exception ex)
            {
                return new Respuesta(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }

        public async Task<Respuesta> SavePartido(Partido partido)
        {
            try
            {
                await _dbContext.Partido.AddAsync(partido);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Respuesta(String.Format(MsjAviso.ErrorDB, TAG));
            }

            return new Respuesta();
        }

        public async Task<Respuesta> UpdatePartido(Partido partido)
        {
            try
            {
                _dbContext.Partido.Update(partido);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Respuesta(String.Format(MsjAviso.ErrorDB, TAG));
            }

            return new Respuesta();
        }

        public async Task<Respuesta> DeletePartido(Partido partido)
        {
            try
            {
                _dbContext.Partido.Update(partido);
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
