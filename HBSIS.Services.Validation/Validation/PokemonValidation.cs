using FluentValidation;
using HBSIS.Services.Model;

namespace HBSIS.Services.Validation
{
    public class PokemonValidation : AbstractValidator<PokemonGO>
    {
        public PokemonValidation()
        {
            RuleFor(s => s.Nome).MaximumLength(10).WithMessage("Deu ruim, campo só cabe 100 caract");
        }
    }
}
