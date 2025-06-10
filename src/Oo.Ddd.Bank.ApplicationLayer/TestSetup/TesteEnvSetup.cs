using Oo.Ddd.Bank.Domain.Model.Factory;
using Oo.Ddd.Bank.Domain.Model;
using Oo.Ddd.Bank.Infrastructure.InMemoryDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Oo.Ddd.Bank.ApplicationLayer.TestSetup
{
    public static class TesteEnvSetup
    {
        private static ContaRepository _contaRepository;

        // Propriedade pública para obter a instância singleton
        public static ContaRepository Instance
        {
            get
            {
                if (_contaRepository == null)
                {
                    _contaRepository = CriarContaRepository();
                }
                return _contaRepository;
            }
        }

        public static ContaRepository CriarContaRepository()
        {
            ContaRepository contaRepository = new();

            Cliente clienteZe = new Cliente();
            clienteZe.Nome = "Zé";
            clienteZe.AdicionarDocumento("CPF", "12345678900");
            clienteZe.AdicionarDocumento("RG", "123456789");

            contaRepository.Adicionar(ContaFactory.Conta(clienteZe, 1, 100));

            Cliente clienteLuiz = new Cliente();
            clienteLuiz.Nome = "Luiz";
            clienteLuiz.AdicionarDocumento("CPF", "12345678901");
            clienteLuiz.AdicionarDocumento("RG", "1234567891");

            contaRepository.Adicionar(ContaFactory.Conta(clienteLuiz, 2));

            return contaRepository;
        }
    }
}
