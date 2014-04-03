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
    public class AnimalApiController : ApiController
    {
        private AnimalRepository _animalRepository = new AnimalRepository();

        // GET api/animalapi
        [Queryable]
        public IEnumerable<AnimalViewModel> Get()
        {
            return _animalRepository.GetAnimais();
        }

        // GET api/animalapi/5
        public string GetAll(int id)
        {
            return "value";
        }

        // POST api/animalapi
        public HttpResponseMessage Post(AnimalModels value)
        {
            value.IdTipo = 1;
            var ct = _animalRepository.Add(value);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, value);

            string uri = Url.Link("DefaultApi", new { id = ct.IdAnimal });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        // PUT api/animalapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/animalapi/5
        public HttpResponseMessage Delete(int id)
        {
            var ct = _animalRepository.Remove(id);
            if (!ct)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
