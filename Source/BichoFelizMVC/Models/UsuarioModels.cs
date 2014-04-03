using System.ComponentModel.DataAnnotations;

namespace BichoFelizMVC.Models
{
    public class UsuarioModels
    {
        public int IdUsuario { get; set; }
        public int? IdContato { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}