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
                            Descricao = l.Descricao,
                            Clientes = (from cliente in context.Set<Cliente>()
                                    where cliente.LojaId == l.Id
                                    select new Cliente {
                                        Id = cliente.Id,
                                        Nome = cliente.Nome,
                                        DataNascimento = cliente.DataNascimento,
                                        Sexo = cliente.Sexo,
                                        Pets = (from pet in context.Set<Pet>()
                                                where pet.ClienteId == cliente.Id
                                                select new Pet {
                                                    Id = pet.Id,
                                                    Nome = pet.Nome,
                                                    Raca = pet.Raca,
                                                    Especie = pet.Especie
                                                }).ToList()
                                    }).ToList()
                        };      
            return lojas.ToList();
        }
    }
}

// Clientes = 

// Pets = 