namespace Oo.Ddd.Bank.WebApp.Models
{
    public class LoginReq
    {
        public int NumeroDaConta { get; set; }
        public string Senha { get; set; }
    }

    public class LoginRes
    {
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
