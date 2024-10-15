using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplos_dynamodb.UseCases.Extensions
{
    public abstract class UseCase<TRequest,TResponse> : IUseCase<TRequest, TResponse>
    {
        IMapper _mapper { get; }

        protected UseCase(IMapper mapper)
        {
            _mapper = mapper;
        }
        public abstract Task<TResponse> ExecutarAsync(TRequest request);
    }
}
