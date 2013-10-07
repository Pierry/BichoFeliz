using System.Collections.Generic;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository.Base
{
    public abstract class ServicoBase : ICrud<ServicoModels>
    {
        #region ICrud<ServicoModels> Members

        public abstract IEnumerable<ServicoModels> Get();
        public abstract ServicoModels Get(int id);
        public abstract bool Add(ServicoModels item);
        public abstract bool Update(ServicoModels item);
        public abstract bool Delete(int id);

        #endregion
    }
}