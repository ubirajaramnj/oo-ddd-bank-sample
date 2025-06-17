
namespace Oo.Ddd.Bank.Domain.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Documento> Documentos { get; set; } = [];

        public void AdicionarDocumento(string tipo, string numero)
        {
            Documentos.Add(new Documento { Tipo = tipo, Numero = numero });
        }
    }

    public class Documento
    {
        public string Tipo { get; set; }
        public string Numero { get; set; }
    }
}