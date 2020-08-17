namespace Domain.Model {
    public class Pet {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Especie { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}