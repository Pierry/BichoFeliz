using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository
{
    public class LoginRepository
    {
        private readonly ContatoRepository _contatoRepository = new ContatoRepository();
        private readonly UsuarioRepository _usuarioRepository = new UsuarioRepository();

        public ContatoModels LogIn(string user, string pass)
        {
            return _usuarioRepository.LogIn(user, pass);
        }

        public int Registrar(RegistrarUsuarioViewModel registrarUsuario)
        {
            var contato = new ContatoModels();
            contato.NomeContato = registrarUsuario.NomeContato;
            contato.Cpf = registrarUsuario.Cidade;
            contato.Endereco = registrarUsuario.Endereco;
            contato.Bairro = registrarUsuario.Bairro;
            contato.Cidade = registrarUsuario.Cidade;
            contato.Estado = registrarUsuario.Estado;
            contato.Perfil = 10;
            contato.Status = 1;

            _contatoRepository.Add(contato);

            var usuario = new UsuarioModels();
            usuario.Email = registrarUsuario.Email;
            usuario.Senha = registrarUsuario.Senha;
            usuario.IdContato = contato.IdContato;

            _usuarioRepository.Add(usuario);

            return usuario.IdUsuario;
        }
    }
}