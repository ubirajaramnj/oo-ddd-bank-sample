using Oo.Ddd.Bank.Domain.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oo.Ddd.Bank.Domain.Model
{
    public class Especial : Conta
    {
        public double Limite { get; set; }
        
        public Especial()
        {
        }

        public override void Sacar(double valor)
        {
            if (valor < 0)
                throw new ValorInvalidoException();

            if (Saldo + Limite <= 0 || valor > Saldo + Limite)
                throw new SaldoInsuficienteException();

            Saldo -= valor;
        }
    }
}
