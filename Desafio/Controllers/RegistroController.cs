using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Services;
using Microsoft.AspNetCore.Mvc;
using Desafio.Models;
using Desafio.Repository;
using Desafio.Repository.Interfaces;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroController : ControllerBase
    {
        private readonly IRegistroRepository _registroRepository;
        private readonly RegistroService _registroService;
        public RegistroController(IRegistroRepository registroRepository, RegistroService registroService)
        {
            _registroRepository = registroRepository;
            _registroService = registroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RegistroModel>>> BuscarRegistros()
        {
            List<RegistroModel> registros = await _registroRepository.BuscarTodosRegistros();

            if (registros.Count == 0)
            {
                return NotFound("Nenhum cadastro encontrado.");
            }

            return Ok(registros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<RegistroModel>>> BuscarPorId(int id)
        {
            List<RegistroModel> registros = await _registroRepository.BuscarPorId(id);

            if (registros.Count == 0)
            {
                return NotFound("Registro não encontrado.");
            }

            return Ok(registros);
        }

        [HttpPost("entrada/{cadastroId}")]
        public async Task<ActionResult<List<IActionResult>>> RegistrarEntrada(int cadastroId)
        {

            await _registroService.RegistrarEntrada(cadastroId);
            return Ok("Entrada registrada com sucesso.");
        }

        [HttpPost("saida/{cadastroId}")]
        public async Task<IActionResult> RegistrarSaida(int cadastroId)
        {
            await _registroService.RegistrarSaida(cadastroId);
            return Ok("Saída registrada com sucesso.");
        }

    }
}