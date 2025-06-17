using Microsoft.AspNetCore.Mvc;
using Oo.Ddd.Bank.WebApp.Models;
using System.Net.Http;

public class ContaController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private static ContaModel conta = new ContaModel
    {
        NumeroConta = "12345",
        Senha = "senha123",
        Saldo = 1000
    };

    public ContaController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(ContaModel model)
    {
        var client = _httpClientFactory.CreateClient();

        var result = client.PostAsJsonAsync("http://localhost:5111/api/login",
            new LoginReq()
            {
                NumeroDaConta = int.Parse(model.NumeroConta),
                Senha = model.Senha
            }).Result;

        if (!result.IsSuccessStatusCode)
        {
            ModelState.AddModelError("", "Erro ao autenticar. Verifique os dados e tente novamente.");
            return View(model);
        }

        ContaRes saldoResult = client.GetFromJsonAsync<ContaRes>("http://localhost:5111/api/Conta/1").Result;
        conta.Saldo = saldoResult.Saldo;

        return RedirectToAction("Saldo");
    }

    public IActionResult Saldo() => View(conta);

    public IActionResult Transferir() => View();

    [HttpPost]
    public IActionResult Transferir(TransferenciaModel model)
    {
        if (model.Valor <= conta.Saldo)
        {
            conta.Saldo -= model.Valor;
            return RedirectToAction("Comprovante", model);
        }

        ModelState.AddModelError("", "Saldo insuficiente para a transferência.");
        
        return View();
    }

    public IActionResult Comprovante(TransferenciaModel model) => View(model);
}