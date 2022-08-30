using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controle_Contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace Controle_Contatos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<ContatoModel> Contatos { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
