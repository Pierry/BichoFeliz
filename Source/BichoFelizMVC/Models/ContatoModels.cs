using System.ComponentModel.DataAnnotations;

namespace BichoFelizMVC.Models {
  public class ContatoModels {
    public int IdContato { get; set; }

    [Required(ErrorMessage = "Nome obrigatório")]
    [DataType(DataType.Text)]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 40 caracteres")]
    [Display(Name = "Nome")]
    
    public string Nome { get; set; }

    [Required(ErrorMessage = "CPF obrigatório")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido")]
    [Display(Name = "CPF")]
    public string Cpf { get; set; }

    [DataType(DataType.Text)]
    [StringLength(30, MinimumLength = 4, ErrorMessage = "Deve conter entre 4 e 30 caracteres")]
    [Display(Name = "Endereço")]
    public string Endereco { get; set; }

    [DataType(DataType.Text)]
    [StringLength(15, MinimumLength = 4, ErrorMessage = "Deve conter entre 4 e 15 caracteres")]
    [Display(Name = "Bairro")]
    public string Bairro { get; set; }

    [Required(ErrorMessage = "Cidade obrigatória")]
    [DataType(DataType.Text)]
    [Display(Name = "Cidade")]
    public string Cidade { get; set; }

    [Display(Name = "Estado")]
    public string Estado { get; set; }

    //Status 0 - Desativado
    //Status 1 - Ativo
    public int? Status { get; set; }

    //Perfil 1 = Cliente
    //Perfil 5 = Funcionario
    //Perfil 10 = Administrador
    public int? Perfil { get; set; }
  }
}