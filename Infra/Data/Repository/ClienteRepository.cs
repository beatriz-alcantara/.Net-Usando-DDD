using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore.Internal;

namespace Data.Repository {
    public class ClienteRepository : BaseRepository<Cliente> {
        public ClienteRepository(PetshopContext ctx) : base(ctx){}
        public dynamic ListagemRelacionamentoLoja() {
            var gp = from cliente in entidade
                     join loj in context.Set<Loja>()
                     on cliente.LojaId equals loj.Id
                     join pet in context.Set<Pet>()
                     on cliente.Id equals pet.ClienteId
                     select new {
                         Id = cliente.Id,
                         Nome = cliente.Nome,
                         DataNascimento = cliente.DataNascimento,
                         Sexo = cliente.Sexo,
                         loja = loj,
                         Pet = pet
                     };
            return gp.ToList();
        }
    }
}