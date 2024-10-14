using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplos_dynamodb.Domain.Entities
{
    [DynamoDBTable("EnderecoTable")]
    public class Endereco
    {
        [DynamoDBHashKey("Status")]
        public string Status { get; set; }

        [DynamoDBRangeKey("Id")]
        public string Id { get; set; }

        [DynamoDBProperty("Rua")]
        public string Rua { get; set; }

        [DynamoDBProperty("Numero")]
        public string Numero { get; set; }

        [DynamoDBProperty("Complemento")]
        public string Complemento { get; set; }

        [DynamoDBProperty("Bairro")]
        public string Bairro { get; set; }

        [DynamoDBProperty("Cidade")]
        public string Cidade { get; set; }

        [DynamoDBProperty("Estado")]
        public string Estado { get; set; }

        [DynamoDBProperty("CEP")]
        public string CEP { get; set; }

        [DynamoDBProperty("Pais")]
        public string Pais { get; set; }

        public Endereco() { }

    }
}
