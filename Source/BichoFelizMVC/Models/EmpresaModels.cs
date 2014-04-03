using System.ComponentModel.DataAnnotations;

namespace BichoFelizMVC.Models
{
    public class EmpresaModels
    {
        public int IdEmpresa { get; set; }
        
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cnpj { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
    }
}