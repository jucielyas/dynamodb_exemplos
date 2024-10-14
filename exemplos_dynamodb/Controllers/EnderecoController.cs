using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using exemplos_dynamodb.Domain.Entities;
using exemplos_dynamodb.UseCases.Endereco.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TesteServicosAWS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IObterTodosEnderecosUseCase _obterTodosEnderecosUseCase;

        public EnderecoController(IObterTodosEnderecosUseCase obterTodosEnderecosUseCase)
        {
            _obterTodosEnderecosUseCase = obterTodosEnderecosUseCase;
        }


        [HttpGet]
        public async Task<IActionResult> ObterTodosEnderecos()
        {
            var enderecos = await _obterTodosEnderecosUseCase.ExecutarAsync();
            return Ok(enderecos);
        }

    }
}