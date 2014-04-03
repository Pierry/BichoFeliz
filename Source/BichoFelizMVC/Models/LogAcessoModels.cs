using System;

namespace BichoFelizMVC.Models
{
    public class LogAcessoModels
    {
        public int IdToken { get; set; }
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime? DataHora { get; set; }
    }
}