using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BichoFelizMVC.Controllers.Repository.Base;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository
{
    public class RacaRepository : RacaBase
    {
        private BichoFelizMVCEntities _db = new BichoFelizMVCEntities();

        public override IEnumerable<RacaModels> Get()
        {
            throw new NotImplementedException();
        }

        public override RacaModels Get(int id)
        {
            throw new NotImplementedException();
        }

        public override RacaModels Add(RacaModels item)
        {
            throw new NotImplementedException();
        }

        public override bool Update(RacaModels item)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}