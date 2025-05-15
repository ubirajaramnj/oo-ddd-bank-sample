using Oo.Ddd.Bank.Domain.Model;
using Oo.Ddd.Bank.Domain.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oo.Ddd.Bank.Domain.Test
{
    [TestClass]
    public class EspecialTest
    {
        [TestMethod]
        public void SaqueDeDezReaisDeUmaContaQueAoFinalTeraSaldoNoventa()
        {
            //Conta deve Ter Saldo 100
            //Conta deve Permitir Sacar 10
            //Conta deve Ter Saldo 90

            var conta = new Especial();
            conta.Saldo = 100;
            double valor = 10;

            conta.Sacar(valor);

            Assert.AreEqual(90, conta.Saldo);
        }

        [TestMethod]
        public void SaqueDeDezReaisDeUmaContaQuePossuiSaldoZeroNaoDeveSerRealizado()
        {
            var conta = new Especial();
            conta.Saldo = 0;
            double valor = 10;

            Assert.ThrowsException<SaldoInsuficienteException>(() => conta.Sacar(valor));
            Assert.AreEqual(0, conta.Saldo);
        }

        [TestMethod]
        public void SaqueDeMenosDezReaisComUmaContaComSaldoCemNaoDeveSerRealizado()
        {
            var conta = new Especial();
            conta.Saldo = 100;
            double valor = -10;

            Assert.ThrowsException<ValorInvalidoException>(() => conta.Sacar(valor));
            Assert.AreEqual(100, conta.Saldo);
        }

        [TestMethod]
        public void SaqueDeDezReaisComUmaContaComSaldoNegativoEmCemReaisNaoDeveSerRealizado()
        {
            var conta = new Especial();
            conta.Saldo = -100;
            double valor = 10;

            Assert.ThrowsException<SaldoInsuficienteException>(() => conta.Sacar(valor));
            Assert.AreEqual(-100, conta.Saldo);
        }

        [TestMethod]
        public void SaqueDeMenosDezReaisComUmaContaComSaldoNegativoEmCemReaisNaoDeveSerRealizado()
        {
            var conta = new Especial();
            conta.Saldo = -100;
            double valor = -10;

            Assert.ThrowsException<ValorInvalidoException>(() => conta.Sacar(valor));
            Assert.AreEqual(-100, conta.Saldo);
        }

        [TestMethod]
        public void SaqueDeDezReaisEmUmaContaEspecialComLimiteDeMilReaisComSaldoNegativoEmCemReaisDeveSerRealizado()
        {
            var conta = new Especial();
            conta.Limite = 1000;
            conta.Saldo = -100;
            double valor = 10;

            conta.Sacar(valor);
            Assert.AreEqual(-110, conta.Saldo);
            Assert.IsTrue(conta.Saldo >= -1000);
        }

        [TestMethod]
        public void SaqueDe1100EmUmaContaEspecialComLimiteDeMilReaisComSaldoNegativoEmCemReaisDeveSerRealizado()
        {
            var conta = new Especial();
            conta.Limite = 1000;
            conta.Saldo = -100;
            double valor = 1100;

            Assert.ThrowsException<SaldoInsuficienteException>(() => conta.Sacar(valor));
            Assert.IsTrue(conta.Saldo >= -1000);
        }
    }
}
