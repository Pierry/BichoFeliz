using System.ComponentModel.DataAnnotations;

namespace BichoFelizMVC.Models {
  public class UsuarioModels {
    public int IdUsuario { get; set; }

    [Required(ErrorMessage = "Email obrigatório")]
    [Display(Name = "Email")]
    [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Email deve ser válido")]
    [StringLength(30, MinimumLength = 6, ErrorMessage = "Email deve conter entre 6 e 30 caracteres")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Senha obrigatória")]
    [Display(Name = "Senha")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "Confirmar senha")]
    [Compare("Senha", ErrorMessage = "Senhas não conferem")]
    [Display(Name = "Confirmar")]
    public string ConfirmarSenha { get; set; }

    public int Status { get; set; }

    public int? IdContato { get; set; }

    public ContatoModels Contato { get; set; }
  }
}