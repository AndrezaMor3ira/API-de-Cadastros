using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Desafio.Models;
using Desafio.Repository.Interfaces;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroRepository _cadastroRepositorio;
        public CadastroController(ICadastroRepository cadastroRepository)
        {
            _cadastroRepositorio = cadastroRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CadastroModel>>> BuscarCadastros()
        {

            List<CadastroModel> cadastros = await _cadastroRepositorio.BuscarTodosCadastros();

            if (cadastros.Count == 0)
            {
                return NotFound("Nenhum cadastro encontrado.");
            }

            return Ok(cadastros);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<CadastroModel>>> BuscarPorId(int id)
        {
            CadastroModel cadastro = await _cadastroRepositorio.BuscarPorId(id);

            if (cadastro == null)
            {
                return NotFound("Cadastro não encontrado.");
            }

            return Ok(cadastro);
        }

        [HttpPost]
        public async Task<ActionResult<CadastroModel>> Cadastrar([FromBody] CadastroModel cadastroModel)
        {
            CadastroModel cadastro = await _cadastroRepositorio.Cadastrar(cadastroModel);
            return Ok(cadastro);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CadastroModel>> Atualizar([FromBody] CadastroModel cadastroModel, int id)
        {
            cadastroModel.Id = id;
            CadastroModel cadastro = await _cadastroRepositorio.Atualizar(cadastroModel, id);
            if (cadastro == null)
            {
                return NotFound("Cadastro não encontrado.");
            }
            return Ok(cadastro);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CadastroModel>> Apagar(int id)
        {
            bool apagado = await _cadastroRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}