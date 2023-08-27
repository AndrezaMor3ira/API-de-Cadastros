using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Desafio.Models;
using Desafio.Data.Map;

namespace Desafio.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<CadastroModel> Cadastros { get; set; }
        public DbSet<RegistroModel> Registros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CadastroMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}