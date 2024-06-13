using Infraestructura.Plataforma;
using Negocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dominio.Modelos;
using Dominio.Entidades;

namespace Infraestructura.Datos.Repositorios
{
    public class RepositorioVoto : IRepositorioVoto
    {
        private readonly string TAG = "Votos";
        private readonly DBContext _dbContext;

        public RepositorioVoto(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Respuesta> PostEjecerVoto(MVotos voto)
        {
            try
            {
                var votoE = new Votos()
                {
                    Id = 0,
                    FechaRegistro = DateTime.Now,
                    IdPartido = voto.IdPartido,
                    IdVotante = voto.IdVotante
                };
                await _dbContext.Voto.AddAsync(votoE);
                _dbContext.SaveChanges();

                return new Respuesta();
            }
            catch (Exception ex)
            {
                return new Respuesta(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }

        public async Task<Respuesta<bool>> VerificarAccionVotar(int idVotante)
        {
            try
            {
                return new Respuesta<bool>(await _dbContext.Voto.AnyAsync(e => e.IdVotante == idVotante));
            }
            catch (Exception ex)
            {
                return new Respuesta<bool>(string.Format(MsjAviso.ErrorDB, TAG));
            }
        }
    }
}
