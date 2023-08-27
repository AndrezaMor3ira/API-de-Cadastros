using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Data.Map
{
    public class CadastroMap : IEntityTypeConfiguration<CadastroModel>
    {
        public void Configure(EntityTypeBuilder<CadastroModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Sobrenome).IsRequired().HasMaxLength(250);
            builder.Property(x => x.AnoDeNascimento).IsRequired().HasMaxLength(4);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(50);

        }
    }
}