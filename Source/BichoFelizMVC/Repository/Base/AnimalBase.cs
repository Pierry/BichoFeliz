using System.Collections.Generic;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository.Base
{
    public abstract class AnimalBase : ICrud<AnimalModels>
    {
        #region ICrud<AnimalModels> Members

        public abstract IEnumerable<AnimalModels> Get();
        public abstract AnimalModels Get(int id);
        public abstract bool Add(AnimalModels item);
        public abstract bool Update(AnimalModels item);
        public abstract bool Delete(int id);

        #endregion
    }
}