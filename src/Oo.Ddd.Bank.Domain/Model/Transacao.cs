namespace Oo.Ddd.Bank.Domain.Model
{
    public class Transacao
    {
        public string Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
    }
}