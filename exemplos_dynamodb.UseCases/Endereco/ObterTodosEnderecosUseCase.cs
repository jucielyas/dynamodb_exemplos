using AutoMapper;
using exemplos_dynamodb.Domain.Entities;
using exemplos_dynamodb.Domain.ViewModels;
using exemplos_dynamodb.Repository;
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
    public class ObterTodosEnderecosUseCase : UseCase<string,List<EnderecoViewModel>>, IObterTodosEnderecosUseCase
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public ObterTodosEnderecosUseCase(IEnderecoRepository enderecoRepository, IMapper mapper) : base(mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public override async Task<List<EnderecoViewModel>> ExecutarAsync(string request)
        {
            var enderecos = await _enderecoRepository.BuscarTodosEnderecosAsync();
            var result = _mapper.Map<List<EnderecoViewModel>>(enderecos);

            return result;
        }
    }
}
