using exemplos_dynamodb.Domain.ViewModels;
using exemplos_dynamodb.UseCases.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplos_dynamodb.UseCases.Endereco.Interfaces
{
    public interface IObterTodosEnderecosUseCase : IUseCase<List<EnderecoViewModel>>
    {
    }
}
