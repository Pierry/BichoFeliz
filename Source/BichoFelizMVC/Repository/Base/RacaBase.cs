using System.Collections.Generic;
using BichoFelizMVC.Controllers.Repository.Interfaces;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Controllers.Repository.Base
{
    public abstract class RacaBase : ICrud<RacaModels>
    {
        #region ICrud<RacaModels> Members

        public abstract IEnumerable<RacaModels> Get();
        public abstract RacaModels Get(int id);
        public abstract RacaModels Add(RacaModels item);
        public abstract bool Update(RacaModels item);
        public abstract bool Remove(int id);

        #endregion
    }
}