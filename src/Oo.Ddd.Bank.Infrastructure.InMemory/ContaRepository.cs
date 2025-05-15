using Oo.Ddd.Bank.Domain.Model;
using Oo.Ddd.Bank.Domain.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oo.Ddd.Bank.Infrastructure.InMemoryDb
{
    public class ContaRepository : IContaRepository
    {
        public List<Conta> Contas { get; set; } = [];

        public void Adicionar(Conta conta)
        {
            Contas.Add(conta);
        }

        public Especial ObterEspecialPorNumero(int numeroConta)
        {
            Conta conta = ObterPorNumero(numeroConta);
            if (conta.GetType().Name == typeof(Especial).Name)
                return (Especial)ObterPorNumero(numeroConta);

            return null;
        }

        public Conta ObterPorNumero(int numeroConta)
        {
            return Contas.Where(c => c.Numero == numeroConta).FirstOrDefault();
        }

        public List<string> TiposDeContas()
        {
            return ["Conta", "Especial"]; //Reflection
        }
    }
}
