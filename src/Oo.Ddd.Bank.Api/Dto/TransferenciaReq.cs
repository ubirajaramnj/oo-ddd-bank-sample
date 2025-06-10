namespace Oo.Ddd.Bank.Api.Dto
{
    public class TransferenciaReq
    {
        public int NumeroDaContaDeOrigem { get; set; }
        public int NumeroDaContaDeDestino { get; set; }
        public double Valor { get; set; }
    }
}
