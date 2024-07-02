using System.ComponentModel.DataAnnotations;

namespace Farmácia_C_.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data_Admissao { get; set; }

        public string Phone{ get; set; }

        public string CPF {  get; set; }

        public string Email { get; set; }
    }
}
