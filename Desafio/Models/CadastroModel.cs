using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Models
{
    public class CadastroModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int AnoDeNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

    }
}