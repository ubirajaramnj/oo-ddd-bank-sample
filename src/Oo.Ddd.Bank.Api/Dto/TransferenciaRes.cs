namespace Oo.Ddd.Bank.Api.Dto
{
    public class TransferenciaRes
    {
        public int NumeroDaContaDeOrigem { get; set; }
        public int NumeroDaContaDeDestino { get; set; }
        public double Valor { get; set; }
        public DateTime DataTransferencia { get; set; }
        public string Status { get; set; }
        public string Mensagem { get; set; }
    }
}
