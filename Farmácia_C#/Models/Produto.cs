namespace Farmácia_C_.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime Data_De_Entrada { get; set; }

        public DateTime Validade { get; set; }

        public float Preco { get; set; }

        public int FornecedorID { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}
