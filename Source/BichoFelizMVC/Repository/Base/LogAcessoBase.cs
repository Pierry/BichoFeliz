using System.Collections.Generic;
using BichoFelizMVC.Controllers.Repository.Interfaces;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Controllers.Repository.Base
{
    public abstract class LogAcessoBase : ICrud<LogAcessoModels>
    {
        #region ICrud<LogAcessoModels> Members

        public abstract IEnumerable<LogAcessoModels> Get();
        public abstract LogAcessoModels Get(int id);
        public abstract LogAcessoModels Add(LogAcessoModels item);
        public abstract bool Update(LogAcessoModels item);
        public abstract bool Remove(int id);

        #endregion
    }
}