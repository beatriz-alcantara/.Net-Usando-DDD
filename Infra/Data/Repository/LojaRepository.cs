using Domain.Model;

namespace Data.Repository {
    public class LojaRepository : BaseRepository<Loja> {
        public LojaRepository(PetshopContext ctx) : base(ctx){}
    }
}