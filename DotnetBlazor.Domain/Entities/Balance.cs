using System.ComponentModel.DataAnnotations;

namespace DotnetBlazor.Domain.Entities
{
    public class Balance
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o Nome!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Preencha as Coordenadas!")]
        public string? Coordinates {  get; set; }

        public ICollection<Camera>? Cameras { get; set; }
    }
}
