using System.ComponentModel.DataAnnotations;

namespace IoTAPI.Models
{
    public class UserEstoque
    {
        [Key]
        public Guid UserEstoqueId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid EstoqueId { get; set; }

        public Ativo Ativo { get; set; } = Ativo.Ativo; 

        public UserEstoque() 
        {
            UserEstoqueId = Guid.NewGuid();
        }
    }
}
