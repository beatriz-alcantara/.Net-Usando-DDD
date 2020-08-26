using Domain.Model;

namespace Data.Repository
{
    public class PetRepository : BaseRepository<Pet> {
        public PetRepository(PetshopContext ctx) : base (ctx){}
    }
}