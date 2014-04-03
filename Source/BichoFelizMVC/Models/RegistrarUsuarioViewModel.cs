using System.ComponentModel.DataAnnotations;

namespace BichoFelizMVC.Models
{
    public class RegistrarUsuarioViewModel
    {
        public int IdContato { get; set; }

        public int IdUsuario { get; set; }

        public int? IdEmpresa { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(30, ErrorMessage = "O email deve conter de 6 a 30 caracteres", MinimumLength = 6)]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "O email deve ser válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(10, ErrorMessage = "A senha deve conter de 4 a 10 caracteres", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Compare("Senha", ErrorMessage = "As senhas devem ser iguais")]
        [DataType(DataType.Password)]
        public string ConfirmarSenha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(30, ErrorMessage = "O nome deve conter de 4 a 30 caracteres", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string NomeContato { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(30, ErrorMessage = "O nome deve conter de 4 a 30 caracteres", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve ser válido")]
        public string Cpf { get; set; }

        [DataType(DataType.Text)]
        public string Endereco { get; set; }

        [DataType(DataType.Text)]
        public string Bairro { get; set; }

        [DataType(DataType.Text)]
        public string Cidade { get; set; }

        [DataType(DataType.Text)]
        [StringLength(2, ErrorMessage = "O estado deve conter 2 caracteres", MinimumLength = 2)]
        public string Estado { get; set; }

        public int? Perfil { get; set; }
        public int? Status { get; set; }
    }
}