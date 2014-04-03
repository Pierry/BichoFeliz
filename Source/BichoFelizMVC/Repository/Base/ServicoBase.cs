using System.Collections.Generic;
using BichoFelizMVC.Controllers.Repository.Interfaces;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Controllers.Repository.Base
{
    public abstract class ServicoBase : ICrud<ServicoModels>
    {
        #region ICrud<ServicoModels> Members

        public abstract IEnumerable<ServicoModels> Get();
        public abstract ServicoModels Get(int id);
        public abstract ServicoModels Add(ServicoModels item);
        public abstract bool Update(ServicoModels item);
        public abstract bool Remove(int id);

        #endregion
    }
}