using System.Collections.Generic;

namespace Domain.Model {
    public class Loja {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
}