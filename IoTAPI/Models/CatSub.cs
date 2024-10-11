using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoTAPI.Models
{
    public class CatSub
    {
        [Key]
        public Guid CatSubId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public Guid SubCategoriaId { get; set; }

        public Ativo Ativo { get; set; } = Ativo.Ativo;

        //Relacionamento Entity Framework
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
        [ForeignKey("SubCategoriaId")]
        public SubCategoria SubCategoria { get; set; }

        //Construtor CatSub
        public CatSub() => CatSubId = Guid.NewGuid();

    }
}
