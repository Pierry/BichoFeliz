namespace BichoFelizMVC.Models {
  public class RacaModels {
    public int IdRaca { get; set; }
    public string NomeRaca { get; set; }
    public int? Status { get; set; }
    public TipoModels Tipo { get; set; }
  }
}