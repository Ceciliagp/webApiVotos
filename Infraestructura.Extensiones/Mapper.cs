using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Extensiones
{
    public static class Mapper
    {
        public static TDestino MapClass<TOrigen, TDestino>(this TOrigen origen)
        where TOrigen : class
        where TDestino : class, new()
        {
            if (origen == null)
                return null;

            var destino = new TDestino();
            var tipoOrigen = typeof(TOrigen);
            var tipoDestino = typeof(TDestino);

            var propiedadesOrigen = tipoOrigen.GetProperties();
            var propiedadesDestino = tipoDestino.GetProperties();

            foreach (var propiedadDestino in propiedadesDestino)
            {
                var propiedadOrigen = propiedadesOrigen.FirstOrDefault(p => p.Name == propiedadDestino.Name);

                if (propiedadOrigen != null && propiedadOrigen.PropertyType == propiedadDestino.PropertyType)
                {
                    // Obtiene el valor de la propiedad del origen y lo asigna a la propiedad del destino
                    propiedadDestino.SetValue(destino, propiedadOrigen.GetValue(origen, null), null);
                }
            }

            return destino;
        }

        public static List<TDestino> MapList<TOrigen, TDestino>(this List<TOrigen> origenList)
        where TOrigen : class
        where TDestino : class, new()
        {
            if (origenList == null)
                return null;

            var destinoList = new List<TDestino>();

            foreach (var origen in origenList)
            {
                var destino = new TDestino();
                var tipoOrigen = typeof(TOrigen);
                var tipoDestino = typeof(TDestino);

                var propiedadesOrigen = tipoOrigen.GetProperties();
                var propiedadesDestino = tipoDestino.GetProperties();

                foreach (var propiedadDestino in propiedadesDestino)
                {
                    var propiedadOrigen = propiedadesOrigen.FirstOrDefault(p => p.Name == propiedadDestino.Name);

                    if (propiedadOrigen != null && propiedadOrigen.PropertyType == propiedadDestino.PropertyType)
                    {
                        // Obtiene el valor de la propiedad del origen y lo asigna a la propiedad del destino
                        var valor = propiedadOrigen.GetValue(origen, null);
                        propiedadDestino.SetValue(destino, valor, null);
                    }
                }

                destinoList.Add(destino);
            }

            return destinoList;
        }
    }
}
