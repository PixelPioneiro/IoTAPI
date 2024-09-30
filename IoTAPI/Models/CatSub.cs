using System.ComponentModel.DataAnnotations;

namespace IoTAPI.Models
{
    public class CatSub
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CategoriaId { get; set; }
        public string SubCategoriaId { get; set; }

        [Required]
        public bool Ativo { get; set; } = true;

        //Relacionamento Entity Framework
        public Categoria Categoria { get; set; }
        public SubCategoria SubCategoria { get; set; }

    }
}
