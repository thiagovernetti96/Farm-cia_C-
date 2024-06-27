namespace Farmácia_C_.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public DateTime Data_Nascimento { get; set; }

        public string Cpf {  get; set; }


        public string Phone { get; set; }
    }
}
