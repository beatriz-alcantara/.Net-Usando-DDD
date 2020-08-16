using System;
using System.Collections.Generic;

namespace Domain.Model {
    public class Cliente {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}