public class TransferenciaModel
{
    public string NumeroContaOrigem { get; set; }
    public string Banco { get; set; }
    public string Agencia { get; set; }
    public string NumeroContaDestino { get; set; }
    public double Valor { get; set; }
}

public class TransferenciaReq
{
    public int NumeroDaContaDeOrigem { get; set; }
    public int NumeroDaContaDeDestino { get; set; }
    public double Valor { get; set; }
}

public class TransferenciaRes
{
    public int NumeroDaContaDeOrigem { get; set; }
    public int NumeroDaContaDeDestino { get; set; }
    public double Valor { get; set; }
    public DateTime DataTransferencia { get; set; }
    public string Status { get; set; }
    public string Mensagem { get; set; }
}