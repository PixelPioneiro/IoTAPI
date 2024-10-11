using IoTAPI.Data;
using IoTAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace IoTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {

        private readonly IoTAPIDbContext _context;

        public ProdutoController(IoTAPIDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetProduto()
        {
            try
            {
                var users = _context.Produto.ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na listagem de produtos. Exceção: {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult PostProduto([FromBody] Produto produto)
        {
            try
            {
                _context.Produto.Add(produto);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok("Produto inserido com sucesso!");
                }
                else
                {
                    return BadRequest("Erro, produto não inserido.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, produto não inserido. Exceção: {ex.Message}");
            }
        }
        [HttpPut]
        public IActionResult PutProduto([FromBody] Produto produto)
        {
            try
            {
                _context.Produto.Update(produto);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok("Produto alterado com sucesso!");
                }
                else
                {
                    return BadRequest("Erro, Produto não alterado.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, Produto não alterado. Exceção: {ex.Message}");
            }
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteProduto([FromRoute] Guid id)
        {
            try
            {
                var produto = _context.Produto.Find(id);

                if (produto.ProdutoId == id)
                {
                    _context.Produto.Remove(produto);
                    var valor = _context.SaveChanges();
                    if (valor == 1)
                    {
                        return Ok("Produto deletado com sucesso!");
                    }
                    else
                    {
                        return BadRequest("Erro, Produto não deletado.");
                    }
                }
                else
                {
                    return NotFound("Erro, Produto não encontrado.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, ao deletar Produto. Exceção: {ex.Message}");
            }
        }
    }
}
