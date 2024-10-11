using IoTAPI.Data;
using IoTAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace IoTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserEstoqueController : Controller
    {
        private readonly IoTAPIDbContext _context;

        public UserEstoqueController(IoTAPIDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetUserEstoque()
        {
            try
            {
                var userEstoques = _context.UserEstoque.ToList();
                return Ok(userEstoques);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na listagem de userEstoque. Exceção: {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult PostUserEstoque([FromBody] UserEstoque userEstoque)
        {
            try
            {
                _context.UserEstoque.Add(userEstoque);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok("UserEstoque inserido com sucesso!");
                }
                else
                {
                    return BadRequest("Erro, UserEstoque não inserido.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, UserEstoque não inserido. Exceção: {ex.Message}");
            }
        }
        [HttpPut]
        public IActionResult PutUserEstoque([FromBody] UserEstoque userEstoque)
        {
            try
            {
                _context.UserEstoque.Update(userEstoque);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok("UserEstoque alterada com sucesso!");
                }
                else
                {
                    return BadRequest("Erro, UserEstoque não alterada.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, UserEstoque não alterada. Exceção: {ex.Message}");
            }
        }
        [HttpDelete("{id:guid}/{nome:string}")]
        public IActionResult DeleteUserEstoque([FromRoute] Guid id)
        {
            try
            {
                var userEstoque = _context.UserEstoque.Find(id);

                if (userEstoque.UserEstoqueId == id && !id.Equals("") && !id.Equals(null))
                {
                    _context.UserEstoque.Remove(userEstoque);
                    var valor = _context.SaveChanges();
                    if (valor == 1)
                    {
                        return Ok("UserEstoque deletada com sucesso!");
                    }
                    else
                    {
                        return BadRequest("Erro, UserEstoque não deletada.");
                    }
                }
                else
                {
                    return NotFound("Erro, UserEstoque não encontrada.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, ao deletar UserEstoque. Exceção: {ex.Message}");
            }
        }
    }
}
