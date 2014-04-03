using System;

namespace BichoFelizMVC.Models
{
    public class ServicoModels
    {
        public int IdServico { get; set; }
        public int IdTipoServico { get; set; }
        public int IdContato { get; set; }
        public string CPF { get; set; }
        public int IdAnimal { get; set; }
        public string DataHora { get; set; }
        public string Periodo { get; set; }
        public int Status { get; set; }
    }

    public class ServicoAnimalModel
    {
        public int IdServico { get; set; }
        public int IdTipoServico { get; set; }
        public int IdContato { get; set; }
        public int IdAnimal { get; set; }
        public string Tipo { get; set; }
        public string NomeContato { get; set; }
        public string Animal { get; set; }
        public string DataHora { get; set; }
        public string Periodo { get; set; }
        public int? Status { get; set; }
    }
}