using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IoTAPI.Models
{
    [PrimaryKey(nameof(UserId), nameof(Email))]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail não é válido")]
        [StringLength(100, ErrorMessage = "O campo deve ter até 100 caracteres")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo nome e obrigatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo nome deve ter de 3 a 50 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo sobrenome deve ter de 3 a 50 caracteres")]
        public string Sobrenome { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O campo login deve ter de 5 a 50 caracteres")]
        public string Login { get; set; } = string.Empty;

        [Required]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "O campo senha de ter no minimo 10 caracteres")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo é obrigatório")]
        public Permission Permission { get; set; } = Permission.User;

        public Ativo Ativo { get; set; } = Ativo.Ativo;

        public User() => UserId = Guid.NewGuid();
    }
}
