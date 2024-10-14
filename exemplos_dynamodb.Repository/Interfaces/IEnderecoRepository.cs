using exemplos_dynamodb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplos_dynamodb.Repository.Interfaces
{
    public interface IEnderecoRepository
    {
        Task SalvarEnderecoAsync(Endereco endereco);
        Task<Endereco> BuscarEnderecoPorIdAsync(string id);
        Task<List<Endereco>> BuscarTodosEnderecosAsync();
        Task DeletarEnderecoAsync(string id);
    }
}
