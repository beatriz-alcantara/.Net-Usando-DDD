using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository {
    public class BaseRepository<C> : IBaseRepository<C> where C : class {
        protected PetshopContext context;
        protected DbSet<C> entidade;
        public BaseRepository(PetshopContext ctx)
        {
            context = ctx;
            entidade = context.Set<C>();
        }
        public virtual Task<List<C>> ListarTodos() {
            return entidade.ToListAsync();
        }
        public void Salvar(C objeto) {
            entidade.Add(objeto);
            context.SaveChanges();
        }
        public C ObterUm(int id) {
            return entidade.Find(id);
        }
        public void Atualizar(C objeto) {
            entidade.Update(objeto);
            context.SaveChanges();
        }
    }
}