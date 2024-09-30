using System.ComponentModel.DataAnnotations;

namespace IoTAPI.Models
{
    public class Categoria
    {
        [Key]
        public Guid Id { get; set; }

        [Key]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo deve conter entre 3 e 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public Ativo Ativo { get; set; }

        //Construtor Categoria
        public Categoria() 
        {
            Id = Guid.NewGuid();
        }
    }
}
