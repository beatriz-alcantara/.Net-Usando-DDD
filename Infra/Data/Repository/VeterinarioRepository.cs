using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class VeterinarioRepository : BaseRepository<Veterinario>
    {
        public VeterinarioRepository(PetshopContext ctx) : base(ctx) { }
        public override List<Veterinario> ListarTodos()
        {
            return entidade.ToList();
        }

        public override Veterinario ObterUm(int id)
        {
            return entidade.Find(id);
        }
    }
}
