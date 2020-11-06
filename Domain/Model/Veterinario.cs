using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Veterinario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Formacao { get; set; }
        public string Descricao { get; set; }
        public int Atendimentos { get; set; }
        public float Satisfacao { get; set; }
    }
}
