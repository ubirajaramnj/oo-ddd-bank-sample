using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oo.Ddd.Bank.Api.Dto;
using Oo.Ddd.Bank.ApplicationLayer;
using Oo.Ddd.Bank.ApplicationLayer.TestSetup;
using Oo.Ddd.Bank.Domain.Model.Repository;
using Oo.Ddd.Bank.Infrastructure.InMemoryDb;

namespace Oo.Ddd.Bank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly ILogger<TransferenciaController> _logger;
        private IContaRepository _contaRepository;
        
        public ContaController(ILogger<TransferenciaController> logger, IContaRepository contaRepository)
        {
            _logger = logger;
            _contaRepository = contaRepository;
        }

        [HttpGet("{conta}")]
        public IActionResult Saldo(int conta)
        {
            var _contaApplicationService = new ContaApplicationService(_contaRepository);

            var contaRecuperada = _contaApplicationService.ObterContaPorNumero(conta);
            return Ok(new SaldoRes(contaRecuperada.Numero, contaRecuperada.Saldo));
        }
    }
}
