using DotnetBlazor.Domain.Entities;
using FluentValidation;

namespace DotnetBlazor.Application.Validators
{
    public class CameraValidator : AbstractValidator<Camera>
    {
        public CameraValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("A descrição é obrigatória.");
            RuleFor(x => x.Brand).NotEmpty().WithMessage("A marca é obrigatória.");
            RuleFor(x => x.Ip).Matches(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$").WithMessage("Endereço IP inválido.");
            RuleFor(x => x.Coordinates).Must(ValidateCoordinates).WithMessage("Coordenadas inválidas.");
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
