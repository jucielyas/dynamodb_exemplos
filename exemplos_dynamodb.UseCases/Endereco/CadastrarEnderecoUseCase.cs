﻿using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using exemplos_dynamodb.Domain.Entities;
using exemplos_dynamodb.Domain.ViewModels;
using exemplos_dynamodb.Repository.Interfaces;
using exemplos_dynamodb.UseCases.Endereco.Interfaces;
using System;
using System.Threading.Tasks;
using exemplos_dynamodb.UseCases.Extensions;

namespace exemplos_dynamodb.UseCases
{
    public class CadastrarEnderecoUseCase : UseCase<EnderecoViewModel,bool>, ICadastrarEnderecoUseCase
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<EnderecoViewModel> _validator;

        public CadastrarEnderecoUseCase(IEnderecoRepository enderecoRepository, IMapper mapper, IValidator<EnderecoViewModel> validator)
            : base(mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public override async Task<bool> ExecutarAsync(EnderecoViewModel enderecoViewModel)
        {
            ValidationResult result = _validator.Validate(enderecoViewModel);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var endereco = _mapper.Map<Domain.Entities.Endereco>(enderecoViewModel);

            endereco.Id = Guid.NewGuid().ToString();

            await _enderecoRepository.SalvarEnderecoAsync(endereco);

            return true;
        }
    }
}