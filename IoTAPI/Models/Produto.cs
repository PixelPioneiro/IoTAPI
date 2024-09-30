using System.ComponentModel.DataAnnotations;

namespace IoTAPI.Models
{
    public class Produto
    {
        [Key]
        public Guid Id { get; set; }

        [Key]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo deve ter entre 3 e 50 caracteres")]
        public string Nome { get; set; }

        [StringLength(300, ErrorMessage = "O campo deve conter entre ate 300 caracteres.")]
        public string? Descricao { get; set; } = "";

        [Required(ErrorMessage = "O campo categoria e obrigatorio.")]
        public string CategoriaId { get; set; }

        [Required(ErrorMessage = "O campo subcategoria e obrigatorio.")]
        public string SubCategoriaId { get; set; }

        [Required]
        public bool Ativo { get; set; } = true;

        //Relacionamento Entity Framework
        public Categoria Categoria {  get; set; }
        public SubCategoria SubCategoria { get; set; }

        //Construtor
        public Produto()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
