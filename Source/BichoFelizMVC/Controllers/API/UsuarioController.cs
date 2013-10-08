using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BichoFelizMVC.Models;
using BichoFelizMVC.Repository.Persistence;

namespace BichoFelizMVC.Controllers.API {
  public class UsuarioController : ApiController {

    private readonly UsuarioRepository _usuarioRepository = new UsuarioRepository();

    // GET api/usuario
    [Queryable]
    public IEnumerable<UsuarioModels> Get() {
      return _usuarioRepository.Get();
    }

    // GET api/usuario/5
    public UsuarioModels Get(int id) {
      return _usuarioRepository.Get(id);
    }

    // POST api/usuario
    public HttpResponseMessage Post(UsuarioModels usuarioModels) {
      if (!ModelState.IsValid) {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
      _usuarioRepository.Add(usuarioModels);

      var response = Request.CreateResponse(HttpStatusCode.Created, usuarioModels);

      string uri = Url.Link("DefaultApi", new { id = usuarioModels.IdUsuario });
      response.Headers.Location = new Uri(uri);

      return response;
    }

    // PUT api/usuario/5
    public HttpResponseMessage Put(int id, UsuarioModels usuarioModels) {
      if (!ModelState.IsValid) {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
      if (id != usuarioModels.IdUsuario) {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
      if (_usuarioRepository.Update(usuarioModels)) {
        return Request.CreateResponse(HttpStatusCode.OK);
      }
      return Request.CreateResponse(HttpStatusCode.NotFound);
    }

    // DELETE api/usuario/5
    public HttpResponseMessage Delete(int id) {
      if (!_usuarioRepository.Delete(id)) {
        return Request.CreateResponse(HttpStatusCode.NotFound);
      }
      return Request.CreateResponse(HttpStatusCode.OK);
    }
  }
}
