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
    public class ServicioCasillas : IServicioCasillas
    {
        public Respuesta<Casilla> EliminarCasilla(MCasilla Casilla)
        {
            Casilla.Activo = false;

            var casillaSave = Casilla.MapClass<MCasilla, Casilla>();

            return new Respuesta<Casilla>(casillaSave);
        }

        public Respuesta<Casilla> VerificarCasilla(MCasilla casilla)
        {
            if (casilla == null) return new Respuesta<Casilla>("El modelo de Casilla no es válido.");

            if (string.IsNullOrWhiteSpace(casilla.Seccion))
                return new Respuesta<Casilla>("La sección de la Casilla es obligatoria.");

            if (casilla.Seccion.Length > 45)
                return new Respuesta<Casilla>("La sección de la Casilla no puede exceder los 45 caracteres.");

            if (casilla.FechaInicio == default)
                return new Respuesta<Casilla>("La fecha de inicio de la Casilla es obligatoria.");

            if (casilla.FechaFin == default)
                return new Respuesta<Casilla>("La fecha de fin de la Casilla es obligatoria.");

            if (casilla.FechaFin <= casilla.FechaInicio)
                return new Respuesta<Casilla>("La fecha de fin debe ser posterior a la fecha de inicio.");

            // Validación opcional del usuario relacionado, si se requiere lógica adicional
            if (casilla.IdUsuario.HasValue && casilla.IdUsuario.Value <= 0)
                return new Respuesta<Casilla>("El IdUsuario debe ser mayor a cero.");

            var casillaSave = casilla.MapClass<MCasilla, Casilla>();

            return new Respuesta<Casilla>(casillaSave);
        }
    }
}
