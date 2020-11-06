using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Map
{
    public class PetMapper
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Especie { get; set; }
        public int ClienteId { get; set; }
    }
}
