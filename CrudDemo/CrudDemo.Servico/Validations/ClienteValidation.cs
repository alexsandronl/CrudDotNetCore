using CrudDemo.Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.Servico.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(x => x.NomeCompleto).NotEmpty()
                .WithMessage("O nome completo é obrigatório");
            RuleFor(x => x.NomeCompleto).NotNull()
                .WithMessage("O nome completo é obrigatório");
            RuleFor(x => x.NomeCompleto).Length(3, 150)
                .WithMessage("O nome cpmpleto deve ter entre 3 e 150 caracteres");

            RuleFor(x => x.DataDeNascimento).NotEqual(default(DateTime))
                .WithMessage("O data de nascimento é obrigatório");
            RuleFor(x => x.DataDeNascimento).GreaterThanOrEqualTo(new DateTime(1900, 1, 1))
                .WithMessage("O data de nascimento não pode ser menor do que 01/01/1900");

            RuleFor(x => x.Documento).NotEmpty()
                .WithMessage("O documento é obrigatório");
            RuleFor(x => x.NomeCompleto).NotNull()
                .WithMessage("O nome documento é obrigatório");
            RuleFor(x => x.Documento).Length(7, 20)
                .WithMessage("O documento deve ter entre 7 e 20 caracteres");

            RuleFor(x => x.Logradouro).MaximumLength(100)
                .WithMessage("O documento deve ter no máximo 100 caracteres");

            RuleFor(x => x.Numero).MaximumLength(15)
                .WithMessage("O documento deve ter no máximo 15 caracteres");

            RuleFor(x => x.Bairro).MaximumLength(50)
                .WithMessage("O documento deve ter no máximo 50 caracteres");

            RuleFor(x => x.Cidade).MaximumLength(50)
                .WithMessage("O documento deve ter no máximo 50 caracteres");

            RuleFor(x => x.UF).MaximumLength(2)
                .WithMessage("O documento deve ter no máximo 2 caracteres");

            RuleFor(x => x.CEP).MaximumLength(8)
                .WithMessage("O documento deve ter no máximo 8 caracteres");
        }

    }
}
