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
    public class ClienteApiController : ApiController
    {
        private readonly ContatoRepository _contatoRepository = new ContatoRepository();

        // GET api/usuarioapi
        [Queryable]
        public IEnumerable<RegistrarUsuarioViewModel> Get()
        {
            return _contatoRepository.GetClientes();
        }

        // GET api/clienteapi/5
        [Queryable]
        public IEnumerable<RegistrarUsuarioViewModel> Get(int idEmpresa)
        {
            return _contatoRepository.GetClientes();
        }
        
        // POST api/clienteapi
        
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
                IdEmpresa = value.IdEmpresa,
                Perfil = 5,
                Status = 1
            };
            var ct = _contatoRepository.AddCliente(contato);
            
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
        public HttpResponseMessage Delete(int id)
        {
            var ct = _contatoRepository.Remove(id);
            if (!ct)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
