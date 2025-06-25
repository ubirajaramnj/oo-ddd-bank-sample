using Oo.Ddd.Bank.WebApp.Models;
using System.Reflection;

namespace Oo.Ddd.Bank.WebApp.Services
{
    public class BankApiClient
    {
        private readonly HttpClient _httpClient;

        public BankApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<LoginRes> LoginAsync(string numeroConta, string senha)
        {
            var response = await _httpClient.PostAsJsonAsync("login",
                            new LoginReq()
                            {
                                NumeroDaConta = int.Parse(numeroConta),
                                Senha = senha
                            });

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<LoginRes>();
        }

        public async Task<ContaRes> GetSaldoAsync(string accountNumber)
        {
            var response = await _httpClient.GetAsync($"Conta/{accountNumber}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ContaRes>();
        }

        public async Task<TransferenciaRes> TransferirAsync(TransferenciaModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("transferencia",
                new TransferenciaReq()
                {
                    NumeroDaContaDeOrigem = int.Parse(model.NumeroContaOrigem),
                    NumeroDaContaDeDestino = int.Parse(model.NumeroContaDestino),
                    Valor = model.Valor
                });
            
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TransferenciaRes>();
        }


    }
}
