using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BichoFelizMVC.Models;
using BichoFelizMVC.Repository.Persistence;

namespace BichoFelizMVC.Controllers.API {
  public class ContatoController : ApiController {
    private readonly ContatoRepository contatoRepository = new ContatoRepository();

    // GET api/contato
    [Queryable]
    public IEnumerable<ContatoModels> Get() {
      return contatoRepository.Get();
    }

    // GET api/contato/5
    public ContatoModels Get(int id) {
      return contatoRepository.Get(id);
    }

    // POST api/contato
    public HttpResponseMessage Post(ContatoModels contatoModels) {
      if (!ModelState.IsValid) {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }

      contatoRepository.Add(contatoModels);
      HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, contatoModels);

      string uri = Url.Link("DefaultApi", new { id = contatoModels.IdContato });
      response.Headers.Location = new Uri(uri);

      return response;
    }

    // PUT api/contato/5
    public HttpResponseMessage Put(int id, ContatoModels value) {
      if (!ModelState.IsValid) {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
      if (id != value.IdContato) {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
      if (contatoRepository.Update(value)) {
        return Request.CreateResponse(HttpStatusCode.OK);
      }
      return Request.CreateResponse(HttpStatusCode.NotFound);
    }

    // DELETE api/contato/5
    public HttpResponseMessage Delete(int id) {
      if (!contatoRepository.Delete(id)) {
        return Request.CreateResponse(HttpStatusCode.NotFound);
      }
      return Request.CreateResponse(HttpStatusCode.OK);
    }
  }
}