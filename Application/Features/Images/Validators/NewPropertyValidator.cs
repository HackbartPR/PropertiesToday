using Application.Models.Property;
using FluentValidation;

namespace Application.Features.Images.Validators
{
    public class NewPropertyValidator : AbstractValidator<NewProperty>
    {
        public NewPropertyValidator() 
        {
            RuleFor(np => np.Name)
                .NotEmpty()
                    .WithMessage("Nome deve ser preenchido")
                .MaximumLength(20)
                    .WithMessage("Número máximo de caracteres (15) excedido");
        }
    }
}
