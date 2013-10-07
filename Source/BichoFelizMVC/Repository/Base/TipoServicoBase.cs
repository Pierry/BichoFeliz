using System.Collections.Generic;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository.Base
{
    public abstract class TipoServicoBase : ICrud<TipoServicoModels>
    {
        #region ICrud<TipoServicoModels> Members

        public abstract IEnumerable<TipoServicoModels> Get();
        public abstract TipoServicoModels Get(int id);
        public abstract bool Add(TipoServicoModels item);
        public abstract bool Update(TipoServicoModels item);
        public abstract bool Delete(int id);

        #endregion
    }
}