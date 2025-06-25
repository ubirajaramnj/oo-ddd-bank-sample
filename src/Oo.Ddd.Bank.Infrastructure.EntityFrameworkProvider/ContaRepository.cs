using Oo.Ddd.Bank.Domain.Model;
using Oo.Ddd.Bank.Domain.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oo.Ddd.Bank.Infrastructure.EntityFrameworkProvider
{
    public class ContaRepository : IContaRepository
    {
        private readonly BankDbContext _context;

        public ContaRepository(BankDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Conta conta)
        {
            _context.Contas.Add(conta);
        }

        public void Update(Conta conta)
        {
            _context.Contas.Update(conta);
        }

        public Especial ObterEspecialPorNumero(int numeroConta) => _context.Especiais
                .Where(c => c.Numero == numeroConta)
                .OfType<Especial>()
                .FirstOrDefault();

        public Conta ObterPorNumero(int numeroConta)
        {
            return _context.Contas
                .Where(c => c.Numero == numeroConta)
                .FirstOrDefault();
        }

        public List<string> TiposDeContas()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }   
    }
}
