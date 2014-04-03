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
    public class UsuarioApiController : ApiController
    {
        private UsuarioRepository _usuarioRepository = new UsuarioRepository();
        private readonly ContatoRepository _contatoRepository = new ContatoRepository();

        // GET api/usuarioapi
        public IEnumerable<UsuarioModels> Get()
        {
            return _usuarioRepository.Get();
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
            var us = _usuarioRepository.Add(usuario);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, value);

            string uri = Url.Link("DefaultApi", new { id = ct.IdContato });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        // PUT api/usuarioapi/5
        public HttpResponseMessage Put(int id, RegistrarUsuarioViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (id != value.IdEmpresa)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var usuario = new UsuarioModels
                          {
                              IdContato = value.IdContato,
                              Email = value.Email,
                              Senha = value.Senha
                          };
            var userBool = _usuarioRepository.Update(usuario);

            var contato = new ContatoModels
                          {
                              Bairro = value.Bairro,
                              IdContato = value.IdContato,
                              Cidade = value.Cidade,
                              Cpf = value.Cpf,
                              Endereco = value.Endereco,
                              Estado = value.Estado,
                              NomeContato = value.NomeContato
                          };
            var cttBool = _contatoRepository.Update(contato);
            if (userBool && cttBool)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // DELETE api/usuarioapi/5
        public HttpResponseMessage Delete(int id)
        {
            var usuario = _usuarioRepository.Remove(id);
            if (!usuario)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
