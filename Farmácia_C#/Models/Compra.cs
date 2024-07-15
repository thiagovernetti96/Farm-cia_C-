using Farmácia_C_.Models;
using System.ComponentModel.DataAnnotations;

namespace Farmácia_C_.Models
{
    public class Compra
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId {  get; set; }

        public Cliente Cliente { get; set; }

        [Required]
        public int FuncionarioId { get; set; }

        public Funcionario Funcionario { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }

    }
}
