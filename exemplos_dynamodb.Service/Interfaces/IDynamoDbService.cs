using System.Collections.Generic;
using System.Threading.Tasks;

namespace exemplos_dynamodb.Service.Interfaces
{
    public interface IDynamoDbService<T> where T : class
    {
        Task SaveAsync(T entity);
        Task<T> GetByIdAsync(object id);
        Task<List<T>> GetAllAsync();
        Task DeleteAsync(object id);
    }
}