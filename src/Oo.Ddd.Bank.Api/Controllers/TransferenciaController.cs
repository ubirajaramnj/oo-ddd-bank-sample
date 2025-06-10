using Microsoft.AspNetCore.Mvc;
using Oo.Ddd.Bank.Api.Dto;
using Oo.Ddd.Bank.ApplicationLayer;
using Oo.Ddd.Bank.ApplicationLayer.TestSetup;
using Oo.Ddd.Bank.Infrastructure.InMemoryDb;

namespace Oo.Ddd.Bank.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TransferenciaController : ControllerBase
{
    private readonly ILogger<TransferenciaController> _logger;
    private static ContaRepository _contaRepository;

    public TransferenciaController(ILogger<TransferenciaController> logger)
    {
        _logger = logger;
        _contaRepository = TesteEnvSetup.Instance;
    }

    [HttpPost]
    public IActionResult Post(TransferenciaReq transferenciaReq)
    {
        try
        {
            TransferenciaEntreContasApplicationService transferenciaEntreContas = new(
            _contaRepository);

            bool resultado = transferenciaEntreContas.Transferir(transferenciaReq.NumeroDaContaDeOrigem,
                            transferenciaReq.NumeroDaContaDeDestino, transferenciaReq.Valor);

            var comprovante = new TransferenciaRes
            {
                NumeroDaContaDeOrigem = transferenciaReq.NumeroDaContaDeOrigem,
                NumeroDaContaDeDestino = transferenciaReq.NumeroDaContaDeDestino,
                Valor = transferenciaReq.Valor,
                DataTransferencia = DateTime.Now,
                Status = resultado ? "Sucesso" : "Falha",
                Mensagem = resultado ? "Transferência realizada com sucesso." : "Erro ao realizar a transferência."
            };

            return Created("", comprovante);
        }
        catch (Exception)
        {
            throw new Exception("Sua mensagem");
        }
    }
}
