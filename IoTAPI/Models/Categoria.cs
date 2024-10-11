using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoTAPI.Models
{
    public class Categoria
    {
        [Key]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório." )]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo deve conter entre 3 e 50 caracteres.")]
        public string Nome { get; set; }

        [StringLength(300, ErrorMessage = "O campo deve conter entre ate 300 caracteres.")]
        public string ? Descricao { get; set; } = "";

        public Ativo Ativo { get; set; } = Ativo.Ativo;

        //Construtor Categoria
        public Categoria() => CategoriaId = Guid.NewGuid();
    }
}
