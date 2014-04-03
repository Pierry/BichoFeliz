using System.Collections.Generic;
using BichoFelizMVC.Controllers.Repository.Interfaces;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Controllers.Repository.Base
{
    public abstract class TipoBase : ICrud<TipoModels>
    {
        #region ICrud<TipoModels> Members

        public abstract IEnumerable<TipoModels> Get();
        public abstract TipoModels Get(int id);
        public abstract TipoModels Add(TipoModels item);
        public abstract bool Update(TipoModels item);
        public abstract bool Remove(int id);

        #endregion
    }
}