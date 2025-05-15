using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oo.Ddd.Bank.Domain.Model.Exceptions
{
    public class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException() : base("Saldo Insuficiente")
        {
        }
    }

    public class ValorInvalidoException : Exception
    {
        public ValorInvalidoException() : base("Valor de Saque Negativo")
        {
        }
    }
}
