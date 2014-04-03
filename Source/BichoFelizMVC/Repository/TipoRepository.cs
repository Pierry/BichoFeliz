using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BichoFelizMVC.Controllers.Repository.Base;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository
{
    public class TipoRepository : TipoBase
    {
        private BichoFelizMVCEntities _db = new BichoFelizMVCEntities();

        public override IEnumerable<TipoModels> Get()
        {
            throw new NotImplementedException();
        }

        public override TipoModels Get(int id)
        {
            throw new NotImplementedException();
        }

        public override TipoModels Add(TipoModels item)
        {
            throw new NotImplementedException();
        }

        public override bool Update(TipoModels item)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}