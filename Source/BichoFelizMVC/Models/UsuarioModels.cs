namespace BichoFelizMVC.Models {
  public class UsuarioModels {
    public int IdUsuario { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public int? IdContato { get; set; }
    public ContatoModels Contato { get; set; }
    public int? Status { get; set; }
  }
}