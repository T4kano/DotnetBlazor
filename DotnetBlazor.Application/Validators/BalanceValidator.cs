using DotnetBlazor.Domain.Entities;
using FluentValidation;

namespace DotnetBlazor.Application.Validators
{
    public class BalanceValidator : AbstractValidator<Balance>
    {
        public void BalancaValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome é obrigatório.");
            RuleFor(x => x.Coordinates).Must(ValidateCoordinates).WithMessage("Coordenadas inválidas.");
            RuleFor(x => x.Cameras).NotEmpty().WithMessage("Pelo menos uma câmera deve ser vinculada à balança.");
        }

        private bool ValidateCoordinates(string coordinates)
        {
            var slices = coordinates.Split(',');
            if (slices.Length != 2) return false;
            return double.TryParse(slices[0], out var lat) && lat >= -90 && lat <= 90 &&
                   double.TryParse(slices[1], out var lon) && lon >= -180 && lon <= 180;
        }
    }
}
