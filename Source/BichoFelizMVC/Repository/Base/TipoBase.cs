using System.Collections.Generic;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository.Base
{
    public abstract class TipoBase : ICrud<TipoModels>
    {
        #region ICrud<TipoModels> Members

        public abstract IEnumerable<TipoModels> Get();
        public abstract TipoModels Get(int id);
        public abstract bool Add(TipoModels item);
        public abstract bool Update(TipoModels item);
        public abstract bool Delete(int id);

        #endregion
    }
}