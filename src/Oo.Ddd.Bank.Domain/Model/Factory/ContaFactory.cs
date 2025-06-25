using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oo.Ddd.Bank.Domain.Model.Factory
{
    public static class ContaFactory
    {
        public static Conta Conta(Cliente cliente, int numero)
        {
            return new Conta
            {
                Cliente = cliente,
            };
        }

        public static Conta Conta(Cliente cliente, int numero, double limite)
        {
            return new Especial
            {
                Limite = limite,
                Saldo = 0,
                Cliente = cliente
            };
        }
    }
}
