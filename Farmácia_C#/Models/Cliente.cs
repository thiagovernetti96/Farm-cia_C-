using System.ComponentModel.DataAnnotations;

namespace Farmácia_C_.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data_Nascimento { get; set; }

        public string Cpf { get; set; }


        public string Phone { get; set; }

        public ICollection<Compra> Compras { get; set; } = new List<Compra>();

        public Cliente() { 
            Compras = new List<Compra>();
        }
    }
}
