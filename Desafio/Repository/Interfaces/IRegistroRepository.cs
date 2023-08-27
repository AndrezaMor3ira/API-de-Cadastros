using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Models;

namespace Desafio.Repository.Interfaces
{
    public interface IRegistroRepository
    {
        Task<List<RegistroModel>> BuscarTodosRegistros();
        Task<List<RegistroModel>> BuscarPorId(int id);
    }
}