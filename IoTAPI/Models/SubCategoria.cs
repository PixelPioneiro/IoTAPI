using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IoTAPI.Models
{
    public class SubCategoria
    {
        [Key]
        public Guid SubCategoriaId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo deve conter entre 3 e 50 caracteres.")]
        public string Nome { get; set; } = "";

        [StringLength(300, ErrorMessage = "O campo deve conter entre ate 300 caracteres.")]
        public string ? Descricao { get; set; } = "";

        public Ativo Ativo { get; set; } = Ativo.Ativo;


        //Construtor
        public SubCategoria() => SubCategoriaId = Guid.NewGuid();
    }
}
