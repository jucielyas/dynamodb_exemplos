using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplos_dynamodb.Domain.ViewModels
{
    public class EnderecoViewModel
    {
        public string Id { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Pais { get; set; }

        public EnderecoViewModel() { }

        public EnderecoViewModel(string rua, string numero, string complemento, string bairro, string cidade, string estado, string cep, string pais)
        {
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            Pais = pais;
        }

        public override string ToString()
        {
            return $"{Rua}, {Numero} {Complemento}, {Bairro}, {Cidade} - {Estado}, {CEP}, {Pais}";
        }
    }
}
