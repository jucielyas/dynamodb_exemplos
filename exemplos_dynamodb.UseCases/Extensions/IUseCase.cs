using System.Threading.Tasks;

namespace exemplos_dynamodb.UseCases.Extensions
{
    public interface IUseCase<TRequest, TResponse>
    {
        Task<TResponse> ExecutarAsync(TRequest request);
    }
}