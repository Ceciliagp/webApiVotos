using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Plataforma
{
    public class MsjAviso
    {
        public static string ErrorDB = "ERROR [500]: {0}";
        public static string ErrorInterno = "ERROR INTERNO: {0}";
        public static string ErrorGenerico = "Ha ocurrido un error inesperado. Intente nuevamente.";
        public static string CampoObligatorioMasculino = "El campo {0} es obligatorio.";
        public static string CampoObligatorioFemenino = "La {0} es obligatorio.";
    }
}
