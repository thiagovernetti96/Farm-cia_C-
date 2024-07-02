namespace Farmácia_C_.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string CNPJ {  get; set; }

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();


        public Fornecedor()
        {
            Produtos = new List<Produto>();
        }
    }
}
