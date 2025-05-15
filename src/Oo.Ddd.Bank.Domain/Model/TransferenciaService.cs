using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oo.Ddd.Bank.Domain.Model
{
    public class TransferenciaService
    {
        public void Transferir(Conta contaOrigem, Conta contaDestino, double valor)
        {  
            contaOrigem.Sacar(valor);
            contaDestino.Depositar(valor);
        }
    }
}
