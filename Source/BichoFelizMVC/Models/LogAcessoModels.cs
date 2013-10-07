using System;

namespace BichoFelizMVC.Models {
  public class LogAcessoModels {
    public int IdToken { get; set; }
    public string Token { get; set; }
    public DateTime? DataHora { get; set; }
    public int? IdUsuario { get; set; }
    public int? Status { get; set; }
    public UsuarioModels Usuario { get; set; }
  }
}