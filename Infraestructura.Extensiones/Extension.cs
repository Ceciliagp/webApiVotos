using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infraestructura.Extensiones
{
    public class Extension
    {
        /// <summary>
        /// Devuelve una condición al evaluar si es nulo o vació
        /// </summary>
        public static bool esNuloOVacio(Object propiedad)
        {
            if (propiedad is string && string.IsNullOrEmpty((string)propiedad))
            {
                return true;
            }

            return propiedad == null;
        }

        public static bool ListaEsNulaOVacia<T>(List<T> lista)
        {
            if (lista == null)
                return true;

            return !lista.Any();
        }


        public static int ConvierteAEntero(object numero)
        {
            try
            {
                int valor;
                int.TryParse(numero.ToString(), out valor);
                return valor;
            }
            catch
            {
                return 0;
            }
        }
        public static float ConvierteAFloat(object numero)
        {
            try
            {
                float valor;
                float.TryParse(numero.ToString(), out valor);
                return valor;
            }
            catch { return 0; }
        }
        public static long ConvierteALargo(object numero)
        {
            try
            {
                long valor;
                long.TryParse(numero.ToString(), out valor);
                return valor;
            }
            catch
            { return 0; }
        }
        public static string ConvierteACadena(object cadena)
        {
            return cadena.ToString().Replace("'", "'");
        }
        public static DateTime ConvierteAFecha(object valor)
        {
            DateTime fecha;
            DateTime.TryParse(valor.ToString(), out fecha);
            return fecha;
        }
        public static string ConvierteASoloFecha(object valor)
        {
            string cadenafecha, dia, mes, anio;
            DateTime fecha;
            DateTime.TryParse(valor.ToString(), out fecha);
            dia = Convert.ToString(fecha.Day);
            mes = Convert.ToString(fecha.Month);
            anio = Convert.ToString(fecha.Year);
            cadenafecha = dia + "/" + mes + "/" + anio;
            return cadenafecha;
        }
        public static TimeSpan ConvierteAHora(object valor)
        {
            TimeSpan hora;
            TimeSpan.TryParse(valor.ToString(), out hora);
            return hora;
        }
        public static Byte[] ConvierteAByte(object valor)
        {
            Byte[] foto;
            foto = (Byte[])(valor);
            return foto;
        }

        public static byte[] StringToBytes(String cadena)
        {
            System.Text.ASCIIEncoding codificador = new System.Text.ASCIIEncoding();
            return codificador.GetBytes(cadena);
        }

        public static byte[] FileToByteArray(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName,
                                           FileMode.Open,
                                           FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }

        public static bool ConvierteABoolean(object obj)
        {
            try
            {
                if (obj == null) return false;

                if (Extension.esNuloOVacio(obj.ToString())) return false;

                if (obj.ToString().Equals("true") || obj.ToString().Equals("1")) return true;

                return false;
            }
            catch
            {
                return false;
            }
        }

        public static string Codificar(string texto)
        {
            try
            {
                if (texto is null)
                    return String.Empty;

                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                return Convert.ToBase64String(bytes);
            }
            catch (Exception e)
            {
                return String.Empty;
            }
        }

        public static string Decodificar(string textoCodificado)
        {
            try
            {
                if (textoCodificado is null)
                    return String.Empty;

                byte[] bytes = Convert.FromBase64String(textoCodificado);
                return Encoding.UTF8.GetString(bytes);
            }
            catch (Exception e)
            {
                return String.Empty;
            }
        }

        public static bool ValidarCorreoElectronico(string correo)
        {
            // Expresión regular para validar correos electrónicos
            string patron = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex regex = new Regex(patron);

            // Verificar si el correo coincide con el patrón
            return regex.IsMatch(correo);
        }

        public static bool ContieneSoloNumeros(string texto)
        {
            string patron = @"^\d+$";
            return Regex.IsMatch(texto, patron); /// TRUE son numeros
        }

        public static string FormatoCompra(DateTime fechaRegistro)
        {
            return fechaRegistro.ToString("ddMMyy");
        }

        public static bool ValidarSoloNumeros(string telefono)
        {
            string PhoneNumberPattern = @"^\d{10}$";
            Regex regex = new Regex(PhoneNumberPattern, RegexOptions.Compiled);
            return regex.IsMatch(telefono);
        }
    }
}
