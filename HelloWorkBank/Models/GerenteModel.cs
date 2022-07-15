namespace HelloWorkBank.Models
{
    public class GerenteModel
    {
        public int IdGerente { get; set; }
        public string NomeGerente { get; set; }

        public IList<ClienteModel> Clientes { get; set; }


    }
}
