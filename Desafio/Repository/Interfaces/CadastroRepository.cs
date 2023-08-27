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
    public class CadastroRepository : ICadastroRepository
    {
        private readonly BancoContext _dbContext;
        public CadastroRepository(BancoContext bancoContext)
        {
            _dbContext = bancoContext;
        }
        public async Task<CadastroModel> BuscarPorId(int id)
        {
            return await _dbContext.Cadastros.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<CadastroModel>> BuscarTodosCadastros()
        {
            return await _dbContext.Cadastros.ToListAsync();
        }
        public async Task<CadastroModel> Cadastrar(CadastroModel cadastro)
        {
            await _dbContext.Cadastros.AddAsync(cadastro);
            await _dbContext.SaveChangesAsync();

            return cadastro;
        }
        public async Task<CadastroModel> Atualizar(CadastroModel cadastro, int id)
        {
            CadastroModel cadastroPorId = await BuscarPorId(id);

            if (cadastroPorId == null)
            {
                throw new Exception($"Cadastro para o ID: {id} não foi encontrado no banco de dados.");
            }

            cadastroPorId.Nome = cadastro.Nome;
            cadastroPorId.Sobrenome = cadastro.Sobrenome;
            cadastroPorId.AnoDeNascimento = cadastro.AnoDeNascimento;
            cadastroPorId.Email = cadastro.Email;
            cadastroPorId.Senha = cadastro.Senha;

            _dbContext.Cadastros.Update(cadastroPorId);
            await _dbContext.SaveChangesAsync();

            return cadastroPorId;
        }
        public async Task<bool> Apagar(int id)
        {

            CadastroModel cadastroPorId = await BuscarPorId(id);

            if (cadastroPorId == null)
            {
                throw new Exception($"Cadastro para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Cadastros.Remove(cadastroPorId);
            await _dbContext.SaveChangesAsync();
            return true;


        }
    }
}