using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exemplos_dynamodb.Domain.ViewModels;
using FluentValidation;

namespace exemplos_dynamodb.UseCases.Endereco.Validators
{
    public class CadastrarEnderecoUseCaseValidator : AbstractValidator<EnderecoViewModel>
    {
        public CadastrarEnderecoUseCaseValidator()
        {
            RuleFor(x => x.Rua)
                .NotEmpty().WithMessage("A rua é obrigatória.")
                .Length(3, 100).WithMessage("A rua deve ter entre 3 e 100 caracteres.");

            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("O número é obrigatório.");

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("A cidade é obrigatória.");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("O estado é obrigatório.")
                .Length(2).WithMessage("O estado deve ter 2 caracteres.");

            RuleFor(x => x.CEP)
                .NotEmpty().WithMessage("O CEP é obrigatório.")
                .Matches(@"^\d{5}-\d{3}$").WithMessage("O CEP deve estar no formato 00000-000.");

            RuleFor(x => x.Pais)
                .NotEmpty().WithMessage("O país é obrigatório.");
        }
    }
}
