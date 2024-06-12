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
    public class ServicioPartido : IServicioPartido
    {
        public Respuesta<Partido> EliminarPartido(MPartido partido)
        {
            partido.Activo = false;

            if(!Extension.esNuloOVacio(partido.ImagenPartido))
                partido.ImagenPartido.Activo = false;

            foreach (var item in partido.Propuestas)
            {
                item.Activo = false;
            }

            var partidoSave = partido.MapClass<MPartido, Partido>();
            //partidoSave.Propuestas = partido.Propuestas.MapList<MPropuesta, Propuesta>();
            //partidoSave.ImagenPartido = partido.ImagenPartido.MapClass<MImagenPartido, ImagenPartido>();

            return new Respuesta<Partido>(partidoSave);
        }

        public Respuesta<Partido> VerificarPartido(MPartido partido, MPartido partidoBD = null)
        {
            if (Extension.esNuloOVacio(partido)) return new Respuesta<Partido>("El Modelo de Partido no es Valido.");

            if (string.IsNullOrWhiteSpace(partido.Nombre))
                return new Respuesta<Partido>("El nombre del Partido es obligatorio.");

            if (partido.Nombre.Length > 50)
                return new Respuesta<Partido>("El nombre del Partido no puede exceder los 50 caracteres.");

            if (string.IsNullOrWhiteSpace(partido.Descripcion))
                return new Respuesta<Partido>("La descripción del Partido es obligatoria.");

            if (partido.Descripcion.Length > 150)
                return new Respuesta<Partido>("La descripción del Partido no puede exceder los 150 caracteres.");

            if (partido.ImagenPartido == null || (partido.ImagenPartido?.Data?.Length ?? 0) == 0)
                return new Respuesta<Partido>("La imagen del Partido es obligatoria.");

            if (string.IsNullOrWhiteSpace(partido.NombreCandidato))
                return new Respuesta<Partido>("El nombre del candidato es obligatorio.");

            if (partido.NombreCandidato.Length > 100)
                return new Respuesta<Partido>("El nombre del candidato no puede exceder los 100 caracteres.");

            if (string.IsNullOrWhiteSpace(partido.ApellidoCandidato))
                return new Respuesta<Partido>("El apellido del candidato es obligatorio.");

            if (partido.ApellidoCandidato.Length > 100)
                return new Respuesta<Partido>("El apellido del candidato no puede exceder los 100 caracteres.");

            var respuesta = VerificarPropuestas(partido.Propuestas, partidoBD);

            if (respuesta.EsError) return new Respuesta<Partido>(respuesta.Mensaje);

            var partidoSave = partido.MapClass<MPartido, Partido>();
            partidoSave.Propuestas = partido.Propuestas.MapList<MPropuesta, Propuesta>();
            partidoSave.ImagenPartido = partido.ImagenPartido.MapClass<MImagenPartido, ImagenPartido>();

            return new Respuesta<Partido>(partidoSave);
        }

        public Respuesta VerificarPropuestas(List<MPropuesta> propuestas, MPartido propuestasBD)
        {
            if(Extension.ListaEsNulaOVacia(propuestas)) return new Respuesta("Por lo menos, el partido debe tener una Propuesta.");

            foreach (var item in propuestas)
            {
                if (Extension.esNuloOVacio(item)) return new Respuesta("Uno de los elementos de las Propuestas no es valido.");
                if (Extension.esNuloOVacio(item.NombreCorto)) return new Respuesta("Hay propuestas sin Nombre Corto");
                if (Extension.esNuloOVacio(item.Descripcion)) return new Respuesta("Hay propuestas sin Descripción.");

                if(!Extension.esNuloOVacio(propuestasBD) && !Extension.ListaEsNulaOVacia(propuestasBD.Propuestas))
                    if (propuestasBD.Propuestas.Any(e => e.NombreCorto.Trim().ToLower().Equals(item.NombreCorto.Trim().ToLower()) && e.Id != item.Id)) return new Respuesta("La Propuesta ya se encuentra en el Listado.");
            }

            return new Respuesta();
        }
    }
}
