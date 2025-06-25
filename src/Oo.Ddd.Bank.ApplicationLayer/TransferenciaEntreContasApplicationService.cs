using Oo.Ddd.Bank.Domain.Model;
using Oo.Ddd.Bank.Domain.Model.Repository;
using Oo.Ddd.Bank.Infrastructure.InMemoryDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oo.Ddd.Bank.ApplicationLayer
{
    public class TransferenciaEntreContasApplicationService
    {
        private IContaRepository _contaRepository;
        private TransferenciaService _transferenciaServices;

        public TransferenciaEntreContasApplicationService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
            _transferenciaServices = new TransferenciaService();
        }

        public bool Transferir(int numeroContaOrigem, int numeroContaDestino, double valor)
        {
            try
            {
                Especial contaOrigem = _contaRepository.ObterEspecialPorNumero(numeroContaOrigem);
                Conta contaDestino = _contaRepository.ObterPorNumero(numeroContaDestino);

                _transferenciaServices.Transferir(contaOrigem, contaDestino, valor);

                _contaRepository.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao transferir: {ex.Message}");
                return false;
            }
        }
    }
}
