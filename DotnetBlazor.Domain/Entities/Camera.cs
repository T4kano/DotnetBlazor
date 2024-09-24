using System.ComponentModel.DataAnnotations;

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

        public ICollection<Balance>? Balances { get; set; }
    }
}
