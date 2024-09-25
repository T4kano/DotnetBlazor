using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace DotnetBlazor.Domain.Entities
{
    public class Balance
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o Nome!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Preencha as Coordenadas!")]
        public string? Coordinates {  get; set; }

        public virtual ICollection<Camera>? Cameras { get; set; } = new List<Camera>();
    }

    public class BalanceValidator : AbstractValidator<Balance>
    {
        public BalanceValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome é obrigatório.");
            RuleFor(x => x.Coordinates).Must(ValidateCoordinates).WithMessage("Coordenadas inválidas.");
            //RuleFor(x => x.Cameras).NotEmpty().WithMessage("Pelo menos uma câmera deve ser vinculada à balança.");
        }

        private bool ValidateCoordinates(string coordinates)
        {
            if (string.IsNullOrWhiteSpace(coordinates)) return false;

            var slices = coordinates.Split(',');

            if (slices.Length != 2) return false;

            var latSuccess = double.TryParse(slices[0].Trim(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var lat);
            var lonSuccess = double.TryParse(slices[1].Trim(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var lon);

            return latSuccess && lat >= -90 && lat <= 90 && lonSuccess && lon >= -180 && lon <= 180;
        }
    }
}
