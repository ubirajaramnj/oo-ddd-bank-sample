using Oo.Ddd.Bank.Domain.Model;
using Oo.Ddd.Bank.Domain.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oo.Ddd.Bank.ApplicationLayer
{
    public class TransferenciaEntreContas
    {
        private IContaRepository _contaRepository;
        private TransferenciaService _transferenciaServices;

        public TransferenciaEntreContas(IContaRepository contaRepository, 
            TransferenciaService transferenciaService)
        {
            _contaRepository = contaRepository;
            _transferenciaServices = transferenciaService;
        }

        public bool Transferir(int numeroContaOrigem, int numeroContaDestino, double valor)
        {
            try
            {
                Conta contaOrigem = _contaRepository.ObterPorNumero(numeroContaOrigem);
                Conta contaDestino = _contaRepository.ObterPorNumero(numeroContaDestino);

                _transferenciaServices.Transferir(contaOrigem, contaDestino, valor);

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
