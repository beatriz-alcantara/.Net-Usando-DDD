using System.Collections.Generic;
using System.Linq;
using Domain.Model;

namespace Data.Repository {
    public class LojaRepository : BaseRepository<Loja> {
        public LojaRepository(PetshopContext ctx) : base(ctx){}
        public override List<Loja> ListarTodos() {
            var lojas = from l in entidade
                        select new Loja {
                            Id = l.Id,
                            Nome = l.Nome,
                            Descricao = l.Descricao
                        };      
            return lojas.ToList();
        }
        public List<Cliente> ListarClientes(int lojaId)
        {
            var clientes = from cliente in context.Set<Cliente>()
                           select new Cliente
                           {
                               Id = cliente.Id,
                               DataNascimento = cliente.DataNascimento,
                               LojaId = cliente.LojaId,
                               Nome = cliente.Nome,
                               Sexo = cliente.Sexo
                           };
            return clientes.ToList();
        }
    }
}

// Clientes = 

// Pets = 