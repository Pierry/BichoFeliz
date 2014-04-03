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
    public class ServicoController : ApiController
    {
        private ServicoRepository _servicoRepository = new ServicoRepository();

        // GET api/servico
        [Queryable]
        public IEnumerable<ServicoAnimalModel> Get()
        {
            return _servicoRepository.GetServicos();
        }

        // GET api/servico/5
        public ServicoAnimalModel Get(int id)
        {
            return _servicoRepository.GetServico(id);
        }

        // POST api/servico
        public HttpResponseMessage Post(ServicoModels value)
        {
            value.IdTipoServico = 2;
            var ct = _servicoRepository.AddServico(value);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, value);

            string uri = Url.Link("DefaultApi", new { id = ct.IdServico });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        // PUT api/servico/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/servico/5
        public HttpResponseMessage Delete(int id)
        {
            var ct = _servicoRepository.Remove(id);
            if (!ct)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
