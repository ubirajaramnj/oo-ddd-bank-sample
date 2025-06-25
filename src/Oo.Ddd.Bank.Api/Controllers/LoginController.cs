using Microsoft.AspNetCore.Mvc;
using Oo.Ddd.Bank.Api.Dto;
using Oo.Ddd.Bank.Domain.Model.Factory;
using Oo.Ddd.Bank.Domain.Model;
using Oo.Ddd.Bank.Infrastructure.EntityFrameworkProvider;

namespace Oo.Ddd.Bank.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        public LoginController(BankDbContext bankDbContext)
        {
            if(bankDbContext.Contas.Count() == 0)
            {
                Cliente clienteZe = new Cliente();
                clienteZe.Nome = "Zé";
                clienteZe.AdicionarDocumento("CPF", "12345678900");
                clienteZe.AdicionarDocumento("RG", "123456789");
                bankDbContext.Clientes.Add(clienteZe);
                bankDbContext.SaveChanges();
                
                bankDbContext.Especiais.Add((Especial)ContaFactory.Conta(clienteZe, 1, 100));
                bankDbContext.SaveChanges();
                
                Cliente clienteLuiz = new Cliente();
                clienteLuiz.Nome = "Luiz";
                clienteLuiz.AdicionarDocumento("CPF", "12345678901");
                clienteLuiz.AdicionarDocumento("RG", "1234567891");
                bankDbContext.Clientes.Add(clienteLuiz);
                bankDbContext.SaveChanges();

                bankDbContext.Contas.Add(ContaFactory.Conta(clienteLuiz, 2));
                bankDbContext.SaveChanges();
            }
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginReq loginRequest)
        {
            if (loginRequest == null || loginRequest.NumeroDaConta == 0 || string.IsNullOrEmpty(loginRequest.Senha))
                return BadRequest(new { Message = "Invalid login request", Token = string.Empty });
            
            
            if (loginRequest.NumeroDaConta == 1 && loginRequest.Senha == "senha123")
                return Ok(new { Message = "Login successful.", Token = "fake-jwt-token" });

            return Unauthorized(new { Message = "Invalid username or password.", Token = string.Empty });
        }
    }
}
