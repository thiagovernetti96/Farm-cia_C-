using System.ComponentModel.DataAnnotations;

namespace Farmácia_C_.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Data_De_Entrada { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Validade { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Preco { get; set; }

        [Required]
        public int FornecedorID { get; set; }

        public Fornecedor Fornecedor { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}
