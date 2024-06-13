using Dominio.Servicios;
using Infraestructura.Datos.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Negocio.IRepositorio;
using Negocio.Servicio;
using Negocio.Servicio.Partidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiVotos.WebApi.Utils
{
    public class Mapping
    {
        public static void StartMappers(IServiceCollection services)
        {
            Mapping.MapperRepository(services);
            Mapping.MapperServicesAplication(services);
            Mapping.MapperServicesDominio(services);
        }

        private static void MapperRepository(IServiceCollection services)
        {
            services.AddTransient<IRepositorioPartidos, RepositorioPartidos>();
            services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
            services.AddTransient<IRepositorioCasillas, RepositorioCasillas>();
            services.AddTransient<IRepositorioVotante, RepositorioVotante>();
            services.AddTransient<IRepositorioVoto, RepositorioVoto>();
        }

        private static void MapperServicesAplication(IServiceCollection services)
        {
            services.AddTransient<INServicioPartido, NServicioPartido>();
            services.AddTransient<INServicioUsuario, NServicioUsuario>();
            services.AddTransient<INServicioCasillas, NServicioCasillas>();
            services.AddTransient<INServicioVotante, NServicioVotante>();
            services.AddTransient<INServicioVoto, NServicioVoto>();
        }

        private static void MapperServicesDominio(IServiceCollection services)
        {
            services.AddTransient<IServicioPartido, ServicioPartido>();
            services.AddTransient<IServicioUsuario, ServicioUsuario>();
            services.AddTransient<IServicioCasillas, ServicioCasillas>();
            services.AddTransient<IServicioVotante, ServicioVotante>();
        }
    }
}
