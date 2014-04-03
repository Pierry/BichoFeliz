namespace BichoFelizMVC.Models
{
    public class AnimalModels
    {
        public int IdAnimal { get; set; }
        public int? IdTipo { get; set; }
        public int? IdContato { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
    }

    public class AnimalViewModel
    {
        public int IdAnimal { get; set; }
        public int? IdTipo { get; set; }
        public int? IdContato { get; set; }
        public int? IdEmpresa { get; set; }
        public string NomeCliente { get; set; }
        public string Nome { get; set; }
    }
}