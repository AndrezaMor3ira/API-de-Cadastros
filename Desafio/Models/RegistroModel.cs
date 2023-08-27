using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Models;

namespace Desafio.Models
{
    public class RegistroModel
    {
        public int Id { get; set; }
        public int CadastroId { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public TimeSpan? TempoPermanencia { get; set; }

        public virtual CadastroModel Cadastro { get; set; }
    }
}