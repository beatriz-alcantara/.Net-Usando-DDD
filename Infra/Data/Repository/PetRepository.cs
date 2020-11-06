using Domain.Model;
using System.Collections.Generic;
using System.Linq;
namespace Data.Repository
{
    public class PetRepository : BaseRepository<Pet> {
        public PetRepository(PetshopContext ctx) : base (ctx){}
        public override List<Pet> ListarTodos() {
            var pets = from pet in entidade
                        join cliente in context.Set<Cliente>()
                        on pet.ClienteId equals cliente.Id
                        select new Pet {
                            Id = pet.Id,
                            Nome = pet.Nome,
                            Raca = pet.Raca,
                            Especie = pet.Especie,
                            ClienteId = pet.ClienteId
                        };
            return pets.ToList();
        }
    }
}