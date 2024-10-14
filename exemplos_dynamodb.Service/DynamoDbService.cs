using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using exemplos_dynamodb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace exemplos_dynamodb.Service
{
    public class DynamoDbService<T> : IDynamoDbService<T> where T : class
    {
        private readonly DynamoDBContext _context;

        public DynamoDbService(IAmazonDynamoDB dynamoDbClient)
        {
            _context = new DynamoDBContext(dynamoDbClient);
        }

        public async Task SaveAsync(T entity)
        {
            try
            {
                await _context.SaveAsync(entity);
                Console.WriteLine("Item salvo com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o item: {ex.Message}");
            }
        }

        public async Task<T> GetByIdAsync(object id)
        {
            try
            {
                var item = await _context.LoadAsync<T>(id);
                if (item != null)
                {
                    Console.WriteLine("Item encontrado.");
                    return item;
                }
                else
                {
                    Console.WriteLine("Item não encontrado.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar o item: {ex.Message}");
                return null;
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                var conditions = new List<ScanCondition>();
                var items = await _context.ScanAsync<T>(conditions).GetRemainingAsync();
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar os itens: {ex.Message}");
                return null;
            }
        }

        public async Task DeleteAsync(object id)
        {
            try
            {
                await _context.DeleteAsync<T>(id);
                Console.WriteLine("Item deletado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar o item: {ex.Message}");
            }
        }
    }
}