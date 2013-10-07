using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BichoFelizMVC.Models;
using BichoFelizMVC.Repository.Persistence;

namespace BichoFelizMVC.Controllers.API {
  public class LogAcessoController : ApiController {
    private readonly LogAcessoRepository logAcessoRepository = new LogAcessoRepository();

    // GET api/logacesso
    [Queryable]
    public IEnumerable<LogAcessoModels> Get() {
      return logAcessoRepository.Get();
    }

    // GET api/logacesso/5
    public LogAcessoModels Get(int id) {
      return logAcessoRepository.Get(id);
    }

    // POST api/logacesso
    public HttpResponseMessage Post(LogAcessoModels logAcesso) {
      if (!ModelState.IsValid) {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
      logAcessoRepository.Add(logAcesso);  

      var response = Request.CreateResponse(HttpStatusCode.Created, logAcesso);

      string uri = Url.Link("DefaultApi", new { id = logAcesso.IdToken });
      response.Headers.Location = new Uri(uri);

      return response;
    }

    // PUT api/logacesso/5
    public HttpResponseMessage Put(int id, LogAcessoModels logAcesso) {
      if (!ModelState.IsValid) {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
      if (id != logAcesso.IdToken) {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
      if (logAcessoRepository.Update(logAcesso)) {
        return Request.CreateResponse(HttpStatusCode.OK);
      }
      return Request.CreateResponse(HttpStatusCode.NotFound);
    }

    // DELETE api/logacesso/5
    public HttpResponseMessage Delete(int id) {
      if (!logAcessoRepository.Delete(id)) {
        return Request.CreateResponse(HttpStatusCode.NotFound);
      }
      return Request.CreateResponse(HttpStatusCode.OK);
    }
  }
}