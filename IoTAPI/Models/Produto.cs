using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IoTAPI.Models
{
    public class Produto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo deve ter entre 3 e 50 caracteres")]
        public string Nome { get; set; }

        [StringLength(300, ErrorMessage = "O campo deve conter entre ate 300 caracteres.")]
        public string? Descricao { get; set; } = "";

        [Required(ErrorMessage = "O campo categoria e obrigatorio.")]
        public Guid CatSubId { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public Ativo Ativo { get; set; }

        //Relacionamento Entity Framework
        public CatSub CatSub {  get; set; }

        //Construtor
        public Produto()
        {
            Id = Guid.NewGuid();
        }
    }
}
