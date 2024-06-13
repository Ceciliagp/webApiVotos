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
    public class ServicioVotante : IServicioVotante
    {
        public Respuesta VerificarCredenciales(string curp, string seccion)
        {
            if (Extension.esNuloOVacio(curp)) return new Respuesta("El parametro curp es Obligatorio.");
            if (!Extension.EsCurpValida(curp)) return new Respuesta("La CURP es inválida.");
            if (Extension.esNuloOVacio(seccion)) return new Respuesta("El parametro sección es Obligatorio.");
            if (!Extension.ContieneSoloNumeros(seccion)) return new Respuesta("El parametro sección solo debe contener caracteres númericos.");

            return new Respuesta();
        }

        public Respuesta<MVotante> VerificarVotante(MVotante votantebd, MCasilla mCasilla, string seccion)
        {
            var fechaActual = DateTime.Now;
            if (Extension.esNuloOVacio(mCasilla)) return new Respuesta<MVotante>($"La Casilla con Sección '{seccion}' no ha sido Registrada. Intente más Tarde.");
            if (mCasilla.FechaInicio.Date == DateTime.MinValue || mCasilla.FechaFin.Date == DateTime.MinValue) return new Respuesta<MVotante>($"La Casilla con Sección '{seccion}' no tiene Fecha y Hora de Inicio y Fin. Comuniquese con el funcionario respectivo.");
            if (fechaActual.Date < mCasilla.FechaInicio.Date) return new Respuesta<MVotante>($"La Casilla con Sección '{seccion}' no ha sido Aperturada hasta las {mCasilla.FechaInicio}. \nComuniquese con el funcionario respectivo.");
            if (fechaActual.Date > mCasilla.FechaFin.Date) return new Respuesta<MVotante>($"La Casilla con Sección '{seccion}' ya fue cerrada desde las {mCasilla.FechaFin}.");

            votantebd.Casilla = mCasilla;
            return new Respuesta<MVotante>(votantebd);
        }
    }
}
