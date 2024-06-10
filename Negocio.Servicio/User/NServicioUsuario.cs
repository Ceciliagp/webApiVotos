using Dominio.Modelos;
using Dominio.Servicios;
using Infraestructura.Extensiones;
using Infraestructura.Plataforma;
using Negocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicio
{
    public class NServicioUsuario : INServicioUsuario
    {
        IRepositorioUsuario repositorio;
        IServicioUsuario servicio;

        public NServicioUsuario(IRepositorioUsuario repositorio, IServicioUsuario servicio)
        {
            this.repositorio = repositorio;
            this.servicio = servicio;
        }

        public async Task<Respuesta> DeleteUsuario(int id)
        {
            var UserBD = await this.GetUsuario(id);

            if (UserBD.EsError) return new Respuesta(UserBD.Mensaje);

            var validacion = servicio.EliminarUsuario(UserBD.Contenido);

            if (validacion.EsError) return new Respuesta(validacion.Mensaje);

            var save = await repositorio.DeleteUsuario(validacion.Contenido);

            if (save.EsError) return new Respuesta(save.Mensaje);

            return new Respuesta();
        }

        public async Task<Respuesta<MUsuario>> GetUsuario(int id)
        {
            return await repositorio.GetUsuarioxId(id);
        }

        public async Task<Respuesta<List<MUsuario>>> GetUsuarios()
        {
            return await repositorio.GetUsuarios();
        }

        public async Task<Respuesta<MUsuario>> PostLogin(MUsuario usuario)
        {
            if (Extension.esNuloOVacio(usuario)) return new Respuesta<MUsuario>("El Modelo de Verificación no es valido.");
            if (Extension.esNuloOVacio(usuario.NombreUsuario)) return new Respuesta<MUsuario>("El Usuario de Verificación no es valido.");
            if (Extension.esNuloOVacio(usuario.Contrasenia)) return new Respuesta<MUsuario>("La Contraseña de Verificación no es valido.");

            return await repositorio.GetUsuarioxUserPass(usuario.NombreUsuario, usuario.Contrasenia);
        }
        

        public async Task<Respuesta> PostUsuario(MUsuario usuario)
        {
            var validacion = servicio.VerificarUsuario(usuario);

            if (validacion.EsError) return new Respuesta(validacion.Mensaje);

            var repetido = await repositorio.UsuarioDuplicado(usuario.NombreUsuario, usuario.Id);

            if (repetido.EsError) return new Respuesta(repetido.Mensaje);

            var save = await repositorio.SaveUsuario(validacion.Contenido);

            if (save.EsError) return new Respuesta(save.Mensaje);

            return new Respuesta();
        }

        public async Task<Respuesta> UpdateUsuario(MUsuario usuario)
        {
            if (Extension.esNuloOVacio(usuario)) return new Respuesta("El Partido no es Valido.");

            var repetido = await repositorio.UsuarioDuplicado(usuario.NombreUsuario, usuario.Id);

            if (repetido.EsError) return new Respuesta(repetido.Mensaje);

            var partidoBD = await repositorio.GetUsuarioxId(usuario.Id);

            if (partidoBD.EsError) return new Respuesta(partidoBD.Mensaje);

            var validacion = servicio.VerificarUsuario(usuario);

            if (validacion.EsError) return new Respuesta(validacion.Mensaje);

            var save = await repositorio.UpdateUsuario(validacion.Contenido);

            if (save.EsError) return new Respuesta(save.Mensaje);

            return new Respuesta();
        }
    }
}
