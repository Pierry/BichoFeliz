using System.Collections.Generic;
using BichoFelizMVC.Controllers.Repository.Interfaces;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Controllers.Repository.Base
{
    public abstract class EmpresaBase : ICrud<EmpresaModels>
    {
        #region ICrud<EmpresaModels> Members

        public abstract IEnumerable<EmpresaModels> Get();
        public abstract EmpresaModels Get(int id);
        public abstract EmpresaModels Add(EmpresaModels item);
        public abstract bool Update(EmpresaModels item);
        public abstract bool Remove(int id);

        #endregion
    }
}