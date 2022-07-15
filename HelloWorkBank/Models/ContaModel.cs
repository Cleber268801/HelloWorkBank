using HelloWorkBank.Models;

namespace HelloWorkBank.Model
{
    public class ContaModel
    {
        public int IdConta { get; set; }

        public string NomeConta { get; set; }

        public IList<ClienteModel> CLientes { get; set; }
    }
}
