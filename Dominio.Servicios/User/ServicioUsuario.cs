using Dominio.Entidades;
using Dominio.Modelos;
using Infraestructura.Extensiones;
using Infraestructura.Plataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicios
{
    public class ServicioUsuario : IServicioUsuario
    {
        public Respuesta<Usuario> EliminarUsuario(MUsuario usuario)
        {
            usuario.Activo = false;
            return new Respuesta<Usuario>(usuario.MapClass<MUsuario, Usuario>());
        }

        public Respuesta<Usuario> VerificarUsuario(MUsuario usuario)
        {
            if (Extension.esNuloOVacio(usuario))
                return new Respuesta<Usuario>("El Modelo de Usuario no es Valido.");

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                return new Respuesta<Usuario>("El nombre del Usuario es obligatorio.");

            if (usuario.Nombre.Length > 50)
                return new Respuesta<Usuario>("El nombre del Usuario no puede exceder los 50 caracteres.");

            if (string.IsNullOrWhiteSpace(usuario.Apellido))
                return new Respuesta<Usuario>("El apellido del Usuario es obligatorio.");

            if (usuario.Apellido.Length > 50)
                return new Respuesta<Usuario>("El apellido del Usuario no puede exceder los 50 caracteres.");

            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                return new Respuesta<Usuario>("El nombre de usuario es obligatorio.");

            if (usuario.NombreUsuario.Length > 50)
                return new Respuesta<Usuario>("El nombre de usuario no puede exceder los 50 caracteres.");

            if (string.IsNullOrWhiteSpace(usuario.Contrasenia))
                return new Respuesta<Usuario>("La contraseña es obligatoria.");

            if (usuario.Contrasenia.Length > 50)
                return new Respuesta<Usuario>("La contraseña no puede exceder los 50 caracteres.");

            if (usuario.IdRol <= 0)
                return new Respuesta<Usuario>("El rol del Usuario es obligatorio.");

            return new Respuesta<Usuario>(usuario.MapClass<MUsuario, Usuario>());
        }
    }
}
