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
    public class EmpresaApiController : ApiController
    {
        private readonly EmpresaRepository _empresaRepository = new EmpresaRepository();

        // GET api/empresaapi
        [Queryable]
        public IEnumerable<EmpresaModels> Get()
        {
            return _empresaRepository.Get();
        }

        // GET api/empresaapi/5
        public string Get(int id)
        {
            return null;
        }

        // POST api/empresaapi
        public HttpResponseMessage Post(EmpresaModels value)
        {
            _empresaRepository.Add(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, value);

            string uri = Url.Link("DefaultApi", new { id = value.IdEmpresa });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        // PUT api/empresaapi/5
        public HttpResponseMessage Put(int id, EmpresaModels value)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (id != value.IdEmpresa)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (_empresaRepository.Update(value))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // DELETE api/empresaapi/5
        public HttpResponseMessage Delete(int id)
        {
            var empresa = _empresaRepository.Remove(id);
            if (!empresa)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
