using System.ComponentModel.DataAnnotations;

namespace BichoFelizMVC.Models
{
    public class ContatoModels
    {
        public int? IdContato { get; set; }
        public int? IdEmpresa { get; set; }
        public string NomeContato { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
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