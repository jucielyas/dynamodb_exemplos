using exemplos_dynamodb.Repository.Interfaces;
using exemplos_dynamodb.Repository;
using exemplos_dynamodb.Service.Interfaces;
using exemplos_dynamodb.Service;
using exemplos_dynamodb.UseCases.Endereco.Interfaces;
using exemplos_dynamodb.UseCases.Endereco;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using exemplos_dynamodb.Models;
using Microsoft.AspNetCore.Hosting;

namespace exemplos_dynamodb.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencies(IServiceCollection services, IConfiguration configuration)
        {
            var awsConfiguration = configuration.GetSection("AWS").Get<AwsConfiguration>();

            services.AddAWSService<IAmazonDynamoDB>(
                new AWSOptions()
                {
                    Credentials = new BasicAWSCredentials(awsConfiguration.AccessKey, awsConfiguration.SecretKey),
                    Region = Amazon.RegionEndpoint.GetBySystemName(awsConfiguration.Region)
                });

            services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

            services.AddScoped(typeof(IDynamoDbService<>), typeof(DynamoDbService<>));

            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            services.AddScoped<IObterTodosEnderecosUseCase, ObterTodosEnderecosUseCase>();

            services.AddAutoMapper(typeof(UseCases.MapperProfile.AutoMapper));

        }
    }
}
