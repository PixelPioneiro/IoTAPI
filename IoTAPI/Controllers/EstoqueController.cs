using IoTAPI.Data;
using IoTAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace IoTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : Controller
    {
        private readonly IoTAPIDbContext _context;

        public EstoqueController(IoTAPIDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetEstoque()
        {
            try
            {
                var users = _context.Estoque.ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na listagem de usuários. Exceção: {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult PostEstoque([FromBody] Estoque estoque)
        {
            try
            {
                _context.Estoque.Add(estoque);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok("Usuário inserido com sucesso!");
                }
                else
                {
                    return BadRequest("Erro, usuário não inserido.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, usuário não inserido. Exceção: {ex.Message}");
            }
        }
        [HttpPut]
        public IActionResult PutEstoque([FromBody] Estoque estoque)
        {
            try
            {
                _context.Estoque.Update(estoque);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok("Estoque alterado com sucesso!");
                }
                else
                {
                    return BadRequest("Erro, estoque não alterado.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, estoque não alterado. Exceção: {ex.Message}");
            }
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEstoque([FromRoute] Guid id)
        {
            try
            {
                var estoque = _context.Estoque.Find(id);

                if (estoque.EstoqueId == id && !id.Equals("") && !id.Equals(null))
                {
                    _context.Estoque.Remove(estoque);
                    var valor = _context.SaveChanges();
                    if (valor == 1)
                    {
                        return Ok("Estoque deletado com sucesso!");
                    }
                    else
                    {
                        return BadRequest("Erro, estoque não deletado.");
                    }
                }
                else
                {
                    return NotFound("Erro, estoque não encontrado.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, ao deletar estoque. Exceção: {ex.Message}");
            }
        }
    }
}
