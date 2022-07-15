using HelloWorkBank.Model;

namespace HelloWorkBank.Models
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }
        public string Nome {get; set; }
        public string CPF { get; set; }
        public int NumeroConta { get; set; }

        public ContaModel ContaModel { get; set; }
        public GerenteModel GerenteModel { get; set; }
        public int IdConta { get; set; }
        public int IdGerente { get; set; }



        public DateTime DataCriacao { get; set; }


    }
}
