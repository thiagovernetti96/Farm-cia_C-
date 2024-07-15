using System.ComponentModel.DataAnnotations;

namespace Farmácia_C_.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$", ErrorMessage = "Telefone inválido")]
        public string Phone { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$|^\d{14}$", ErrorMessage = "CNPJ inválido")]
        public string CNPJ {  get; set; }

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();


        public Fornecedor()
        {
            Produtos = new List<Produto>();
        }
    }
}
