using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoASPNetCoreBaltaIO.Repositories.Interfaces
{
    public interface IRepository<TType, TKey, TViewModel> where TType : class
    {
        Task<IEnumerable<TViewModel>> Get();

        Task<TType> Get(TKey id);

        Task Save(TType entity);

        Task Update(TType entity);

        Task Delete(TType entity);
    }
}