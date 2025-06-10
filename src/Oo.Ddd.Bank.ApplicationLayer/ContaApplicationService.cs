using Oo.Ddd.Bank.Domain.Model;
using Oo.Ddd.Bank.Domain.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oo.Ddd.Bank.ApplicationLayer
{
    public class ContaApplicationService
    {
        private readonly IContaRepository _contaRepository;

        public ContaApplicationService(IContaRepository contaRepository) {
            _contaRepository = contaRepository;
        }

        public Conta ObterContaPorNumero(int numeroConta)
        {
            return _contaRepository.ObterPorNumero(numeroConta);
        }
    }
}
