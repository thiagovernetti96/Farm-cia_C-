using System.ComponentModel.DataAnnotations;

namespace Farmácia_C_.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data_De_Entrada { get; set; }

        [DataType(DataType.Date)]
        public DateTime Validade { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Preco { get; set; }

        public int FornecedorID { get; set; }

        public Fornecedor Fornecedor { get; set; }

        public int Quantidade { get; set; }
    }
}
