using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces {
    public interface IBaseRepository<T> {
        List<T> ListarTodos();
        void Salvar(T entidade);
        T ObterUm(int id);
        void Atualizar(T objeto);
    } 
}