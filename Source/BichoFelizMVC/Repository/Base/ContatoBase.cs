using System.Collections.Generic;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository.Base
{
    public abstract class ContatoBase : ICrud<ContatoModels>
    {
        #region ICrud<ContatoModels> Members

        public abstract IEnumerable<ContatoModels> Get();
        public abstract ContatoModels Get(int id);
        public abstract bool Add(ContatoModels item);
        public abstract bool Update(ContatoModels item);
        public abstract bool Delete(int id);

        #endregion
    }
}