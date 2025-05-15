
using Oo.Ddd.Bank.Domain.Model;
using Oo.Ddd.Bank.Domain.Model.Exceptions;

namespace Oo.Ddd.Bank.Domain.Test
{
    [TestClass]
    public sealed class ContaTest
    {
        [TestMethod]
        public void SaqueDeDezReaisDeUmaContaQueAoFinalTeraSaldoNoventa()
        {
            //Conta deve Ter Saldo 100
            //Conta deve Permitir Sacar 10
            //Conta deve Ter Saldo 90

            var conta = new Conta();
            conta.Saldo = 100;
            double valor = 10;

            conta.Sacar(valor);

            Assert.AreEqual(90, conta.Saldo);
        }

        [TestMethod]
        public void SaqueDeDezReaisDeUmaContaQuePossuiSaldoZeroNaoDeveSerRealizado()
        {
            var conta = new Conta();
            conta.Saldo = 0;
            double valor = 10;

            Assert.ThrowsException<SaldoInsuficienteException>(() => conta.Sacar(valor));
            Assert.AreEqual(0, conta.Saldo);
        }

        [TestMethod]
        public void SaqueDeMenosDezReaisComUmaContaComSaldoCemNaoDeveSerRealizado()
        {
            var conta = new Conta();
            conta.Saldo = 100;
            double valor = -10;

            Assert.ThrowsException<ValorInvalidoException>(() => conta.Sacar(valor));
            Assert.AreEqual(100, conta.Saldo);
        }

        [TestMethod]
        public void SaqueDeDezReaisComUmaContaComSaldoNegativoEmCemReaisNaoDeveSerRealizado()
        {
            var conta = new Conta();
            conta.Saldo = -100;
            double valor = 10;

            Assert.ThrowsException<SaldoInsuficienteException>(() => conta.Sacar(valor));
            Assert.AreEqual(-100, conta.Saldo);
        }

        [TestMethod]
        public void SaqueDeMenosDezReaisComUmaContaComSaldoNegativoEmCemReaisNaoDeveSerRealizado()  
        {
            var conta = new Conta();
            conta.Saldo = -100;
            double valor = -10;

            Assert.ThrowsException<ValorInvalidoException>(() => conta.Sacar(valor));
            Assert.AreEqual(-100, conta.Saldo);
        }
    }
}
