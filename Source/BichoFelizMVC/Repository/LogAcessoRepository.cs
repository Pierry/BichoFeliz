using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BichoFelizMVC.Controllers.Repository.Base;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository
{
    public class LogAcessoRepository : LogAcessoBase
    {
        private BichoFelizMVCEntities _db = new BichoFelizMVCEntities();

        public override IEnumerable<LogAcessoModels> Get()
        {
            throw new NotImplementedException();
        }

        public override LogAcessoModels Get(int id)
        {
            throw new NotImplementedException();
        }

        public override LogAcessoModels Add(LogAcessoModels item)
        {
            throw new NotImplementedException();
        }

        public override bool Update(LogAcessoModels item)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}