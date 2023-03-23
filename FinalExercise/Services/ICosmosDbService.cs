using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalExercise.Services
{
    public interface ICosmosDbService<T> where T : class
    {        
        Task<T> GetFirst(string queryString);
        Task Add(T item, string id);
        Task Update(string id, T counter);
        Task Delete(string id);
        Task<T> GetById(string id);
        Task<IEnumerable<T>> Get(string queryString);
    }
}