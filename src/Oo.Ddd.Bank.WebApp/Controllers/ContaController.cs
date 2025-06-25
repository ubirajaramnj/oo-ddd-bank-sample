using Microsoft.AspNetCore.Mvc;
using Oo.Ddd.Bank.WebApp.Models;
using Oo.Ddd.Bank.WebApp.Services;

public class ContaController : Controller
{
    private readonly BankApiClient _bankApiClient;
    
    public ContaController(BankApiClient httpClient)
    {
        _bankApiClient = httpClient;
    }

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(ContaModel contaModel)
    {
        var result = _bankApiClient.LoginAsync(contaModel.NumeroConta, contaModel.Senha).Result;

        if (string.IsNullOrEmpty(result.Token))
        {
            ModelState.AddModelError("", "Erro ao autenticar. Verifique os dados e tente novamente.");
            return View(contaModel);
        }

        
        return RedirectToAction("Saldo", new { numeroConta = contaModel.NumeroConta });
    }

    public IActionResult Saldo(string numeroConta) {
        ContaRes saldoResult = _bankApiClient.GetSaldoAsync(numeroConta).Result;
        ContaModel conta = new ContaModel
        {
            NumeroConta = saldoResult.NumeroConta.ToString(),
            Saldo = saldoResult.Saldo
        };
        
        return View(conta);
    }

    public IActionResult Transferir(string numeroConta) {
        return View(new TransferenciaModel
        {
            NumeroContaOrigem = numeroConta
        }); 
    }

    [HttpPost]
    public IActionResult Transferir(TransferenciaModel model)
    {
        var transfRes = _bankApiClient.TransferirAsync(model).Result;
        if(transfRes == null)
        {
            ModelState.AddModelError("", "Saldo insuficiente para a transferência.");
            return View(model);
        }
        return RedirectToAction("Comprovante", model);
    }

    public IActionResult Comprovante(TransferenciaModel model) => View(model);
}