using IoTAPI.Data;
using IoTAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace IoTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoriaController : Controller
    {
        private readonly IoTAPIDbContext _context;

        public SubCategoriaController(IoTAPIDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetSubCategoria()
        {
            try
            {
                var subcategorias = _context.SubCategoria.ToList();
                return Ok(subcategorias);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na listagem de subcategoria. Exceção: {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult PostSubCategoria([FromBody] SubCategoria subcategoria)
        {
            try
            {
                _context.SubCategoria.Add(subcategoria);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok("Subcategoria inserida com sucesso!");
                }
                else
                {
                    return BadRequest("Erro, subcategoria não inserido.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, subcategoria não inserida. Exceção: {ex.Message}");
            }
        }
        [HttpPut]
        public IActionResult PutSubCategoria([FromBody] SubCategoria subcategoria)
        {
            try
            {
                _context.SubCategoria.Update(subcategoria);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok("subcategoria alterada com sucesso!");
                }
                else
                {
                    return BadRequest("Erro, subcategoria não alterada.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, subcategoria não alterada. Exceção: {ex.Message}");
            }
        }
        [HttpDelete("{id:guid}/{nome:string}")]
        public IActionResult DeleteSubCategoria([FromRoute] Guid id, string nome)
        {
            try
            {
                var subcategoria = _context.SubCategoria.Find(id, nome);

                if (subcategoria.Nome == nome && subcategoria.SubCategoriaId == id)
                {
                    _context.SubCategoria.Remove(subcategoria);
                    var valor = _context.SaveChanges();
                    if (valor == 1)
                    {
                        return Ok("Subcategoria deletada com sucesso!");
                    }
                    else
                    {
                        return BadRequest("Erro, subcategoria não deletada.");
                    }
                }
                else
                {
                    return NotFound("Erro, subcategoria não encontrada.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, ao deletar subcategoria. Exceção: {ex.Message}");
            }
        }
    }
}
