using System.ComponentModel.DataAnnotations;

namespace IoTAPI.Models
{
    public class CatSub
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public Guid SubCategoriaId { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public Ativo Ativo { get; set; }

        //Relacionamento Entity Framework
        public Categoria Categoria { get; set; }
        public SubCategoria SubCategoria { get; set; }

        //Construtor CatSub
        public CatSub()
        {
            Id = Guid.NewGuid();
        }

    }
}
