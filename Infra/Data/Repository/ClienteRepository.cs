using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore.Internal;

namespace Data.Repository {
    public class ClienteRepository : BaseRepository<Cliente> {
        public ClienteRepository(PetshopContext ctx) : base(ctx){}
        public override List<Cliente> ListarTodos() {
            var gp = from cliente in entidade
                     join loj in context.Set<Loja>()
                     on cliente.LojaId equals loj.Id
                     select new Cliente {
                         Id = cliente.Id,
                         Nome = cliente.Nome,
                         DataNascimento = cliente.DataNascimento,
                         Sexo = cliente.Sexo,
                         loja = loj,
                         Pets = (from pet in context.Set<Pet>()
                         where cliente.Id== pet.ClienteId
                         select new Pet{
                             Id = pet.Id,
                             Nome = pet.Nome,
                             Raca = pet.Raca,
                             Especie = pet.Especie
                         }).ToList()
                     };
            return gp.ToList();
        }
        public override Cliente ObterUm(int id) {
            var cliente = entidade.Find(id);
            var lojas = from loja in context.Set<Loja>()
                           where loja.Id == cliente.LojaId
                           select new Loja {
                               Id = loja.Id,
                               Nome = loja.Nome,
                               Descricao = loja.Descricao
                            };

            var pets = from pet in context.Set<Pet>()
                        where pet.ClienteId == cliente.Id
                        select new Pet {
                            Id = pet.Id,
                            Nome = pet.Nome,
                            Especie = pet.Especie,
                            Raca = pet.Raca
                        };
            cliente.loja = lojas.First();
            cliente.Pets = pets.ToList();
            return cliente;
        }
    }
}