using System;
using System.Collections.Generic;
using Domain.Enums;
using Domain.Model;

namespace Domain.Map {
    public class ClienteMapper {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        //public ICollection<Pet> Pets { get; set; }
    }
}