using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Data;
using Desafio.Models;

namespace Desafio.Services
{
    public class RegistroService
    {
        private readonly BancoContext _dbContext;
        public RegistroService(BancoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task RegistrarEntrada(int cadastroId)
        {

            var ultimaSaida = _dbContext.Registros.OrderByDescending(x => x.Saida).FirstOrDefault(x => x.CadastroId == cadastroId);

            if (ultimaSaida == null || ultimaSaida.Saida.HasValue)
            {
                var novaEntrada = new RegistroModel
                {
                    CadastroId = cadastroId,
                    Entrada = DateTime.Now
                };
                _dbContext.Registros.Add(novaEntrada);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Não é possível registrar a entrada sem ter encerrado a entrada anterior");
            }
        }

        public async Task RegistrarSaida(int cadastroId)
        {
            var entradaPendente = _dbContext.Registros.OrderByDescending(x => x.Entrada).FirstOrDefault(x => x.CadastroId == cadastroId && x.Saida == null);

            if (entradaPendente != null)
            {
                entradaPendente.Saida = DateTime.Now;
                entradaPendente.TempoPermanencia = entradaPendente.Saida - entradaPendente.Entrada;

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Não é possível registrar uma saída sem uma entrada.");
            }
        }
    }
}