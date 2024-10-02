using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoTAPI.Models
{
    public class Estoque
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo nome e obrigatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo deve conter entre 3 e 50 caracteres.")]
        public string Nome { get; set; }

        [StringLength(300, ErrorMessage = "O campo descricao deve ter no maximo 300 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo usuario e obrigatorio.")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "O campo id e obrigatorio.")]
        public Guid ProdutoId { get; set; }

        [Required(ErrorMessage = "O campo data e obrigatorio.")]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }

        [Required(ErrorMessage = "O campo quantidade e obrigatorio.")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal QuantidadeIn {  get; set; } = 0;

        [Required(ErrorMessage = "O campo data e obrigatorio.")]
        [DataType(DataType.DateTime)]
        public DateTime DataIn {  get; set; }

        [Required(ErrorMessage = "O campo quantidade e obrigatorio.")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal QuantidadeOut { get; set; } = 0;

        [Required(ErrorMessage = "O campo data e obrigatorio.")]
        [DataType(DataType.DateTime)]
        public DateTime DataOut { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public Ativo Ativo { get; set; }

        //Relacionamento Entity Framework
        public Produto Produto { get; set; }
        public User User { get; set; }

        //Construtor Estoque
        public Estoque()
        {
            Id = Guid.NewGuid();
        }
    }
}
