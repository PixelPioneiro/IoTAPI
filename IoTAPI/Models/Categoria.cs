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

        [Required]
        public bool Ativo { get; set; } = true;

        //Construtor Categoria
        public Categoria() 
        {
            this.Id = Guid.NewGuid();
        }
    }
}
