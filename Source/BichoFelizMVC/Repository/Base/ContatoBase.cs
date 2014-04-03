using System.Collections.Generic;
using BichoFelizMVC.Controllers.Repository.Interfaces;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Controllers.Repository.Base
{
    public abstract class ContatoBase : ICrud<ContatoModels>
    {
        #region ICrud<ContatoModels> Members

        public abstract IEnumerable<ContatoModels> Get();
        public abstract ContatoModels Get(int id);
        public abstract ContatoModels Add(ContatoModels item);
        public abstract bool Update(ContatoModels item);
        public abstract bool Remove(int id);

        #endregion
    }
}