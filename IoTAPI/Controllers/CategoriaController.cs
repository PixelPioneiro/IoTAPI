using IoTAPI.Data;
using IoTAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace IoTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly IoTAPIDbContext _context;

        public CategoriaController(IoTAPIDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetCategoria()
        {
            try
            {
                var categorias = _context.Categoria.ToList();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na listagem de categoria. Exceção: {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult PostCategoria([FromBody] Categoria categoria)
        {
            try
            {
                _context.Categoria.Add(categoria);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok("Categoria inserido com sucesso!");
                }
                else
                {
                    return BadRequest("Erro, Categoria não inserido.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, Categoria não inserido. Exceção: {ex.Message}");
            }
        }
        [HttpPut]
        public IActionResult PutCategoria([FromBody] Categoria categoria)
        {
            try
            {
                _context.Categoria.Update(categoria);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok("Categoria alterada com sucesso!");
                }
                else
                {
                    return BadRequest("Erro, Categoria não alterada.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, Categoria não alterada. Exceção: {ex.Message}");
            }
        }
        [HttpDelete("{id:guid}/{nome:string}")]
        public IActionResult DeleteCategoria([FromRoute] Guid id, string nome)
        {
            try
            {
                var categoria = _context.Categoria.Find(id, nome);

                if (categoria.Nome == nome && categoria.CategoriaId == id)
                {
                    _context.Categoria.Remove(categoria);
                    var valor = _context.SaveChanges();
                    if (valor == 1)
                    {
                        return Ok("Categoria deletada com sucesso!");
                    }
                    else
                    {
                        return BadRequest("Erro, Categoria não deletada.");
                    }
                }
                else
                {
                    return NotFound("Erro, Categoria não encontrada.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, ao deletar Categoria. Exceção: {ex.Message}");
            }
        }
    }
}
