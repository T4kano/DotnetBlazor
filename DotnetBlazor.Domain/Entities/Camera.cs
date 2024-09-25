using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace DotnetBlazor.Domain.Entities
{
    public class Camera
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha a Descrição!")]
        [StringLength(100)]
        public string? Description {  get; set; }

        [Required(ErrorMessage = "Preencha a Marca!")]
        [StringLength(100)]
        public string? Brand { get; set; }


        [Required(ErrorMessage = "Preencha o IP!")]
        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "Endereço IP inválido.")]
        public string? Ip { get; set; }

        [Required(ErrorMessage = "Preencha as Coordenadas!")]
        public string? Coordinates { get; set; }

        public virtual ICollection<Balance>? Balances { get; set; } = new List<Balance>();
    }

    public class CameraValidator : AbstractValidator<Camera>
    {
        public CameraValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("A descrição é obrigatória.");
            RuleFor(x => x.Brand).NotEmpty().WithMessage("A marca é obrigatória.");
            RuleFor(x => x.Ip).NotEmpty().WithMessage("O endereço IP é obrigatório!.").Matches(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$").WithMessage("Endereço IP inválido.");
            RuleFor(x => x.Coordinates).Must(ValidateCoordinates).WithMessage("Coordenadas inválidas.");
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
