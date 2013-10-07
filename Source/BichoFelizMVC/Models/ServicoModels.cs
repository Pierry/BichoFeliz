using System;

namespace BichoFelizMVC.Models {
  public class ServicoModels {
    public int IdServico { get; set; }
    public DateTime? DataHora { get; set; }
    public int? Periodo { get; set; }
    public int? Situacao { get; set; }
    public TipoServicoModels TipoServico { get; set; }
    public ContatoModels Contato { get; set; }
    public AnimalModels Animal { get; set; }
  }
}