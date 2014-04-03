using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BichoFelizMVC.Models;
using BichoFelizMVC.Repository;

namespace BichoFelizMVC.Controllers.API
{
    public class ContatoApiController : ApiController
    {
        private UsuarioRepository _usuarioRepository = new UsuarioRepository();
        private readonly ContatoRepository _contatoRepository = new ContatoRepository();

        // GET api/usuarioapi
        public IEnumerable<RegistrarUsuarioViewModel> Get()
        {
            return _contatoRepository.GetUsuarios(1);
        }

        // GET api/usuarioapi/5
        public IEnumerable<RegistrarUsuarioViewModel> Get(int idEmpresa)
        {
            return _contatoRepository.GetUsuarios(idEmpresa);
        }
        
        // POST api/usuarioapi
        public HttpResponseMessage Post(RegistrarUsuarioViewModel value)
        {
            var contato = new ContatoModels
                          {
                              Bairro = value.Bairro,
                              Cidade = value.Cidade,
                              Cpf = value.Cpf,
                              Endereco = value.Endereco,
                              Estado = value.Estado,
                              NomeContato = value.NomeContato,
                              Perfil = 5,
                              Status = 1,
                              IdEmpresa = value.IdEmpresa
                          };
            var ct = _contatoRepository.Add(contato);
            var usuario = new UsuarioModels
                          {
                              Email = value.Email,
                              Senha = value.Senha,
                              IdContato = ct.IdContato
                          };
            _usuarioRepository.Add(usuario);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, value);

            string uri = Url.Link("DefaultApi", new { id = ct.IdContato });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        // PUT api/usuarioapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/usuarioapi/5
        public void Delete(int id)
        {
        }
    }
}
