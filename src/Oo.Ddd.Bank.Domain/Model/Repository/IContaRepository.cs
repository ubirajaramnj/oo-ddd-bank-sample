using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Oo.Ddd.Bank.Domain.Model.Repository
{
    public interface IContaRepository
    {
        public void Adicionar(Conta conta);

        //List<Conta> ObterTodas(); 
        
        Conta ObterPorNumero(int numeroConta);
        Especial ObterEspecialPorNumero(int numeroConta);



        List<string> TiposDeContas();

        //void Remover(int numeroConta);


        //void Atualizar(Conta conta);

        void Save();
    }
}
