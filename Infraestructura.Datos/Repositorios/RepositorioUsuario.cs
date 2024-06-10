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
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly string TAG = "Usuarios";
        private readonly DBContext _dbContext;

        public RepositorioUsuario(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Respuesta> DeleteUsuario(Usuario Usuario)
        {
            try
            {
                _dbContext.Usuario.Update(Usuario);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Respuesta(String.Format(MsjAviso.ErrorDB, TAG));
            }

            return new Respuesta();
        }

        public async Task<Respuesta<List<MUsuario>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _dbContext.Usuario.Where(e => e.Activo).Select(p => new MUsuario
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    NombreUsuario = p.NombreUsuario,
                    Contrasenia = p.Contrasenia,
                    Activo = p.Activo,
                    IdRol = p.IdRol,
                    Rol = p.Rol.MapClass<Roles, MRol>()
                }).ToListAsync();

                return new Respuesta<List<MUsuario>>(usuarios);
            }
            catch (Exception ex)
            {
                return new Respuesta<List<MUsuario>>(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }

        public async Task<Respuesta<MUsuario>> GetUsuarioxId(int id)
        {
            try
            {
                var consulta = await _dbContext.Usuario
                                 .Where(p => p.Id == id)
                                 .Select(p => new MUsuario
                                 {
                                     Id = p.Id,
                                     Nombre = p.Nombre,
                                     Apellido = p.Apellido,
                                     NombreUsuario = p.NombreUsuario,
                                     Contrasenia = p.Contrasenia,
                                     Activo = p.Activo,
                                     IdRol = p.IdRol,
                                     Rol = new MRol
                                     {
                                         Id = p.Rol.Id,
                                         Activo = p.Rol.Activo,
                                         Rol = p.Rol.Rol
                                     }
                                 }).FirstOrDefaultAsync();


                if (Extension.esNuloOVacio(consulta) || !consulta.Activo) return new Respuesta<MUsuario>("El Usuario fue previamente eliminado.");

                return new Respuesta<MUsuario>(consulta);
            }
            catch (Exception ex)
            {
                return new Respuesta<MUsuario>(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }

        public async Task<Respuesta<MUsuario>> GetUsuarioxUserPass(string user, string password)
        {
            try
            {
                var consulta = await _dbContext.Usuario
                                 .Where(p => p.NombreUsuario == user && p.Contrasenia == password)
                                 .Select(p => new MUsuario
                                 {
                                     Id = p.Id,
                                     Nombre = p.Nombre,
                                     Apellido = p.Apellido,
                                     NombreUsuario = p.NombreUsuario,
                                     Contrasenia = p.Contrasenia,
                                     Activo = p.Activo,
                                     IdRol = p.IdRol,
                                     Rol = new MRol
                                     {
                                         Id = p.Rol.Id,
                                         Activo = p.Rol.Activo,
                                         Rol = p.Rol.Rol
                                     }
                                 }).FirstOrDefaultAsync();


                if (Extension.esNuloOVacio(consulta) || !consulta.Activo) return new Respuesta<MUsuario>("El Usuario fue previamente eliminado.");

                return new Respuesta<MUsuario>(consulta);
            }
            catch (Exception ex)
            {
                return new Respuesta<MUsuario>(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }

        public async Task<Respuesta> SaveUsuario(Usuario usuario)
        {
            try
            {
                await _dbContext.Usuario.AddAsync(usuario);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Respuesta(String.Format(MsjAviso.ErrorDB, TAG));
            }

            return new Respuesta();
        }

        public async Task<Respuesta> UpdateUsuario(Usuario Usuario)
        {
            try
            {
                _dbContext.Usuario.Update(Usuario);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Respuesta(String.Format(MsjAviso.ErrorDB, TAG));
            }

            return new Respuesta();
        }

        public async Task<Respuesta> UsuarioDuplicado(string nombre, int id)
        {
            try
            {
                if (await _dbContext.Usuario.AnyAsync(e => e.NombreUsuario.Equals(nombre) && e.Id != id && e.Activo)) return new Respuesta("El Usuario ya se encuentra registrado.");

                return new Respuesta();
            }
            catch (Exception ex)
            {
                return new Respuesta(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }
    }
}
