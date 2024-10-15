using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using exemplos_dynamodb.Domain.Entities;
using exemplos_dynamodb.Domain.ViewModels;
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
        private readonly ICadastrarEnderecoUseCase _cadastrarEnderecoUseCase;
        public EnderecoController(IObterTodosEnderecosUseCase obterTodosEnderecosUseCase, ICadastrarEnderecoUseCase cadastrarEnderecoUseCase)
        {
            _obterTodosEnderecosUseCase = obterTodosEnderecosUseCase;
            _cadastrarEnderecoUseCase = cadastrarEnderecoUseCase;
        }


        [HttpGet]
        public async Task<IActionResult> ObterTodosEnderecos()
        {
            var enderecos = await _obterTodosEnderecosUseCase.ExecutarAsync("");
            return Ok(enderecos);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarEndereco([FromBody] EnderecoViewModel enderecoViewModel)
        {
            var enderecoCadastrado = await _cadastrarEnderecoUseCase.ExecutarAsync(enderecoViewModel);

            if (enderecoCadastrado)
            {
                return Ok(enderecoCadastrado);
            }

            return StatusCode(500, "Erro ao cadastrar o endereço.");
        }

    }
}