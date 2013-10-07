using System.Collections.Generic;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository.Base
{
    public abstract class RacaBase : ICrud<RacaModels>
    {
        #region ICrud<RacaModels> Members

        public abstract IEnumerable<RacaModels> Get();
        public abstract RacaModels Get(int id);
        public abstract bool Add(RacaModels item);
        public abstract bool Update(RacaModels item);
        public abstract bool Delete(int id);

        #endregion
    }
}