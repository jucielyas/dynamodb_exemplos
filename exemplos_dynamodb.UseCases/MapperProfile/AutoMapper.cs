using AutoMapper;
using exemplos_dynamodb.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplos_dynamodb.UseCases.MapperProfile
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap <Domain.Entities.Endereco, EnderecoViewModel>().ReverseMap();
        }
    }
}
