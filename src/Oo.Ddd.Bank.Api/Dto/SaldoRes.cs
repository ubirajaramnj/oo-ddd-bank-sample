namespace Oo.Ddd.Bank.Api.Dto
{
    public class SaldoRes
    {
        public int NumeroConta { get; set; }
        public double Saldo { get; set; }
        
        public SaldoRes(int numeroConta, double saldo)
        {
            NumeroConta = numeroConta;
            Saldo = saldo;
        }
        public SaldoRes() { } // Construtor padrão para serialização
    }
}
