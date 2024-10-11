using Microsoft.AspNetCore.Mvc;
using IoTAPI.Data;
using IoTAPI.Models;

namespace IoTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IoTAPIDbContext _context;

        public UserController(IoTAPIDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetUser()
        {
            try
            {
                var users = _context.User.ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na listagem de usuários. Exceção: {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult PostUser([FromBody] User user)
        {
            try
            {
                _context.User.Add(user);
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
        public IActionResult PutUser([FromBody] User user)
        {
            try
            {
                _context.User.Update(user);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok("Usuário alterado com sucesso!");
                }
                else
                {
                    return BadRequest("Erro, usuário não alterado.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, usuário não alterado. Exceção: {ex.Message}");
            }
        }
        [HttpDelete("{id:guid}/{email:string}")]
        public IActionResult DeleteUser([FromRoute] Guid id, string email)
        {
            try
            {
                var user = _context.User.Find(id, email);

                if (user.Email == email && user.UserId == id)
                {
                    _context.User.Remove(user);
                    var valor = _context.SaveChanges();
                    if (valor == 1)
                    {
                        return Ok("Usuário deletado com sucesso!");
                    }
                    else
                    {
                        return BadRequest("Erro, usuário não deletado.");
                    }
                }
                else
                {
                    return NotFound("Erro, usuário não encontrado.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, ao deletar usuário. Exceção: {ex.Message}");
            }
        }
    }
}
