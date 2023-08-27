using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Desafio.Data.Map
{
    public class RegistroMap : IEntityTypeConfiguration<RegistroModel>
    {
        public void Configure(EntityTypeBuilder<RegistroModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Entrada).IsRequired();
            builder.Property(x => x.Saida);
            builder.Property(x => x.TempoPermanencia);
            builder.Property(x => x.CadastroId).IsRequired();

            builder.HasOne(x => x.Cadastro);
        }
    }
}