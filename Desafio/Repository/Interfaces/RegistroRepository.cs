using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Data;
using Desafio.Models;
using Desafio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repository.Interfaces
{
    public class RegistroRepository : IRegistroRepository
    {
        private readonly BancoContext _dbContext;
        public RegistroRepository(BancoContext bancoContext)
        {
            _dbContext = bancoContext;
        }

        public async Task<List<RegistroModel>> BuscarPorId(int id)
        {
            List<RegistroModel> registros = await _dbContext.Registros
    .Where(x => x.CadastroId == id)
    .ToListAsync();

            return registros;
        }

        public async Task<List<RegistroModel>> BuscarTodosRegistros()
        {
            return await _dbContext.Registros.ToListAsync();
        }
    }
}