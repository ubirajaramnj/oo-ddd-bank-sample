// See https://aka.ms/new-console-template for more information
using Oo.Ddd.Bank.ApplicationLayer;
using Oo.Ddd.Bank.Domain.Model;
using Oo.Ddd.Bank.Domain.Model.Factory;
using Oo.Ddd.Bank.Infrastructure.InMemoryDb;

Console.WriteLine("Hello, World!");

ContaRepository contaRepository = new ContaRepository();

Cliente clienteZe = new Cliente();
clienteZe.Nome = "Zé";
clienteZe.AdicionarDocumento("CPF","12345678900");
clienteZe.AdicionarDocumento("RG", "123456789");

contaRepository.Adicionar(ContaFactory.Conta(clienteZe, 1, 100));

Cliente clienteLuiz = new Cliente();
clienteLuiz.Nome = "Luiz";
clienteLuiz.AdicionarDocumento("CPF", "12345678901");
clienteLuiz.AdicionarDocumento("RG", "1234567891");

contaRepository.Adicionar(ContaFactory.Conta(clienteLuiz, 2));

//Cliente Zé solicita uma transferência para o cliente Luiz de 20
TransferenciaEntreContas transferencia = 
    new TransferenciaEntreContas(contaRepository, new TransferenciaService());

transferencia.Transferir(1, 2, 20);

Console.WriteLine($"Saldo da conta do {clienteZe.Nome}: {contaRepository.ObterPorNumero(1).Saldo}");
Console.WriteLine($"Saldo da conta do {clienteLuiz.Nome}: {contaRepository.ObterPorNumero(2).Saldo}");

Console.ReadLine();

