using Microsoft.AspNetCore.Mvc;

public class ContaController : Controller
{
    private static ContaModel conta = new ContaModel
    {
        NumeroConta = "12345",
        Senha = "senha123",
        Saldo = 1000m
    };

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(ContaModel model)
    {
        if (model.NumeroConta == conta.NumeroConta && model.Senha == conta.Senha)
        {
            return RedirectToAction("Saldo");
        }
        ModelState.AddModelError("", "Número da conta ou senha incorretos.");
        return View();
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