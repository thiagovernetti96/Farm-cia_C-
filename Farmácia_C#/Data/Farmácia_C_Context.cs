using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Farmácia_C_.Models;

namespace Farmácia_C_.Data
{
    public class Farmácia_C_Context : DbContext
    {
        public Farmácia_C_Context (DbContextOptions<Farmácia_C_Context> options)
            : base(options)
        {
        }

        public DbSet<Farmácia_C_.Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<Farmácia_C_.Models.Funcionario>? Funcionario { get; set; }

        public DbSet<Farmácia_C_.Models.Fornecedor>? Fornecedor { get; set; }

        public DbSet<Farmácia_C_.Models.Produto>? Produto { get; set; }

        public DbSet<Farmácia_C_.Models.Compra>? Compra { get; set; }
    }
}
