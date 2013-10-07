using System.Collections.Generic;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository.Base
{
    public abstract class LogAcessoBase : ICrud<LogAcessoModels>
    {
        #region ICrud<LogAcessoModels> Members

        public abstract IEnumerable<LogAcessoModels> Get();
        public abstract LogAcessoModels Get(int id);
        public abstract bool Add(LogAcessoModels item);
        public abstract bool Update(LogAcessoModels item);
        public abstract bool Delete(int id);

        #endregion
    }
}