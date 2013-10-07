namespace BichoFelizMVC.Models {
  public class AnimalModels{
    public int IdAnimal { get; set; }
    public string NomeAnimal { get; set; }
    public int? IdContato { get; set; }
    public int? Status { get; set; }
    public RacaModels Raca { get; set; }
    public ContatoModels Contato { get; set; }
  }
}