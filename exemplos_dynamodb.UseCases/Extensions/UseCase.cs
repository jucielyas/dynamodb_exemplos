using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplos_dynamodb.UseCases.Extensions
{
    public abstract class UseCase<T> : IUseCase<T>
    {
        public abstract Task<T> ExecutarAsync();
    }
}
