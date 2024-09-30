using System.ComponentModel.DataAnnotations;

namespace IoTAPI.Models
{
    public class SubCategoria
    {
        [Key]
        public Guid Id { get; set; }

        [Key]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo deve conter entre 3 e 50 caracteres.")]
        public string Nome { get; set; }

        [StringLength(300, ErrorMessage = "O campo deve conter entre ate 300 caracteres.")]
        public string ? Descricao { get; set; } = "";

        [Required(ErrorMessage = "O campo categoria e obrigatorio.")]
        public string CategoriaId { get; set; }

        [Required]
        public bool Ativo { get; set; } = true;

        //Relacionamento Entity Framework
        public Categoria Categoria { get; set; }
    }
}
