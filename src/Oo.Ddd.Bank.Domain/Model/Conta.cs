using Oo.Ddd.Bank.Domain.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Oo.Ddd.Bank.Domain.Model
{
    public class Agencia
    {
        public int Numero { get; set; }
        
        private int UltimoNumeroDeContaGerado { get; set; }

        public List<Conta> Contas { get; set; } = [];

        public void AdicionarConta(Conta conta)
        {
            Contas.Add(conta);
        }

        public List<Conta> RecuperarContasDo(Cliente cliente)
        {
            return Contas.Where(c => c.Cliente.Nome == cliente.Nome).ToList();
        }

        private int GenerateAccountNumber()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }

    }

    public class Conta
    {
        public int Numero { get; set; }
        public double Saldo { get; set; }

        public Cliente Cliente { get; set; } = new();

        public List<Transacao> Transacoes { get; set; } = [];

        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        public virtual void Sacar(double valor)
        {
            if (valor < 0)
                throw new ValorInvalidoException();

            if (Saldo <= 0 || valor > Saldo)
                throw new SaldoInsuficienteException();
            
            Saldo -= valor;
        }

        public void ReprossessamentoDoSaldo()
        {
            Saldo = 0;
        }

        public List<Transacao> Extrato(DateTime dataInicio, DateTime dataFinal)
        {
            return [.. Transacoes.Where(t => t.Data >= dataInicio && t.Data <= dataFinal)];
        }
    }
}
