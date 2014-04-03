using System.Collections.Generic;
using BichoFelizMVC.Controllers.Repository.Interfaces;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Controllers.Repository.Base
{
    public abstract class TipoServicoBase : ICrud<TipoServicoModels>
    {
        #region ICrud<TipoServicoModels> Members

        public abstract IEnumerable<TipoServicoModels> Get();
        public abstract TipoServicoModels Get(int id);
        public abstract TipoServicoModels Add(TipoServicoModels item);
        public abstract bool Update(TipoServicoModels item);
        public abstract bool Remove(int id);

        #endregion
    }
}