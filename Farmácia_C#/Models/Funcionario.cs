using System.ComponentModel.DataAnnotations;

namespace Farmácia_C_.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required]
        [MinLength(8)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Data_Admissao { get; set; }

        [Required]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$", ErrorMessage = "Telefone inválido")]
        public string Phone{ get; set; }

        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$|^\d{11}$", ErrorMessage = "CPF inválido")]
        public string CPF {  get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
    }
}
