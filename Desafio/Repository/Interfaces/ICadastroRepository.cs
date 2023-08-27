using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Models;

namespace Desafio.Repository.Interfaces
{
    public interface ICadastroRepository
    {
        Task<List<CadastroModel>> BuscarTodosCadastros();
        Task<CadastroModel> BuscarPorId(int id);

        Task<CadastroModel> Cadastrar(CadastroModel cadastro);
        Task<CadastroModel> Atualizar(CadastroModel cadastro, int id);
        Task<bool> Apagar(int id);
    }
}