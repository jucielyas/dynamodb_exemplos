using exemplos_dynamodb.Domain.ViewModels;
using exemplos_dynamodb.Repository.Interfaces;
using exemplos_dynamodb.UseCases.Endereco.Interfaces;
using exemplos_dynamodb.UseCases.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplos_dynamodb.UseCases.Endereco
{
    public class ObterTodosEnderecosUseCase : UseCase<List<EnderecoViewModel>>, IObterTodosEnderecosUseCase
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public ObterTodosEnderecosUseCase(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }


        public override async Task<List<EnderecoViewModel>> ExecutarAsync()
        {
            var enderecos = await _enderecoRepository.BuscarTodosEnderecosAsync();

            return new List<EnderecoViewModel>();
        }
    }
}
