using System.Collections.Generic;
using BichoFelizMVC.Controllers.Repository.Interfaces;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Controllers.Repository.Base
{
    public abstract class AnimalBase : ICrud<AnimalModels>
    {
        #region ICrud<AnimalModels> Members

        public abstract IEnumerable<AnimalModels> Get();
        public abstract AnimalModels Get(int id);
        public abstract AnimalModels Add(AnimalModels item);
        public abstract bool Update(AnimalModels item);
        public abstract bool Remove(int id);

        #endregion
    }
}