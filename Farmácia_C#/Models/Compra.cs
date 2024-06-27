namespace Farmácia_C_.Models
{
    public class Compra
    {
        public int Id { get; set; }

        public int ClienteId {  get; set; }

        public Cliente Cliente { get; set; }

        public int FuncionarioId { get; set; }

        public Funcionario Funcionario { get; set; }

        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

    }
}
