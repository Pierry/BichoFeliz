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
    public class TipoApiController : ApiController
    {
        private readonly ServicoRepository _servicoRepository = new ServicoRepository();

        // GET api/tipoapi
        public IEnumerable<TipoServicoModels> Get()
        {
            return _servicoRepository.GetTipos();
        }

        // GET api/tipoapi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/tipoapi
        public HttpResponseMessage Post(TipoServicoModels value)
        {
            var ct = _servicoRepository.AddTipo(value);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, value);

            string uri = Url.Link("DefaultApi", new { id = ct.IdTpServico });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        // PUT api/tipoapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tipoapi/5
        public HttpResponseMessage Delete(int id)
        {
            var ct = _servicoRepository.RemoveTipo(id);
            if (!ct)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
