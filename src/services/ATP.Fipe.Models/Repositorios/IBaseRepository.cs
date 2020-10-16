using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATP.Fipe.Models
{
    public interface IBaseRepository<T> where T : class
    {
        T Obter(string id);

        IQueryable<T> Obter();

        void Inserir(IList<T> modelo);

        void Inserir(T modelo);

        Task InserirAsync(IList<T> modelo);

        Task InserirAsync(T modelo);

        void Atualizar(T modelo);

        void Remover(string id);        
    }
}
