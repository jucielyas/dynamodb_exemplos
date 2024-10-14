using Amazon.DynamoDBv2.Model;
using exemplos_dynamodb.Domain.Entities;
using exemplos_dynamodb.Repository.Interfaces;
using exemplos_dynamodb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplos_dynamodb.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly IDynamoDbService<Endereco> _dynamoDbService;

        public EnderecoRepository(IDynamoDbService<Endereco> dynamoDbService)
        {
            _dynamoDbService = dynamoDbService;
        }

        public async Task SalvarEnderecoAsync(Endereco endereco)
        {
            try
            {
                await _dynamoDbService.SaveAsync(endereco);
                Console.WriteLine("Endereço salvo com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o endereço: {ex.Message}");
            }
        }

        public async Task<Endereco> BuscarEnderecoPorIdAsync(string rua)
        {
            try
            {
                var endereco = await _dynamoDbService.GetByIdAsync(rua);
                if (endereco != null)
                {
                    Console.WriteLine("Endereço encontrado.");
                    return endereco;
                }
                else
                {
                    Console.WriteLine("Endereço não encontrado.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar o endereço: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Endereco>> BuscarTodosEnderecosAsync()
        {
            try
            {
                var enderecos = await _dynamoDbService.GetAllAsync();
                return enderecos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar os endereços: {ex.Message}");
                return null;
            }
        }

        public async Task DeletarEnderecoAsync(string rua)
        {
            try
            {
                await _dynamoDbService.DeleteAsync(rua);
                Console.WriteLine("Endereço deletado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar o endereço: {ex.Message}");
            }
        }

        public async void BuscarEnderecosPaginados(string ultimaChaveRecebida)
        {

            //var requestQuery = new QueryRequest
            //{
            //    TableName = "EnderecoTable",
            //    Limit = 10, // Número de itens por página
            //    ExclusiveStartKey = ultimaChaveRecebida == null ? new Dictionary<string, AttributeValue>() : null,
            //    KeyConditionExpression = "NewHashKey = :valIndex",
            //    ExpressionAttributeValues = new Dictionary<string, AttributeValue>
            //    {
            //        { ":val", new AttributeValue { N = "0" } },
            //        { ":valIndex", new AttributeValue { S = "OK" } }
            //    },
            //    ScanIndexForward = false
            //};
        }

    }
}
