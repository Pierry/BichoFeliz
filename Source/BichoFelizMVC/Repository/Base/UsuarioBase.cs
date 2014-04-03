using System.Collections.Generic;
using BichoFelizMVC.Controllers.Repository.Interfaces;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Controllers.Repository.Base
{
    public abstract class UsuarioBase : ICrud<UsuarioModels>
    {
        #region ICrud<UsuarioModels> Members

        public abstract IEnumerable<UsuarioModels> Get();
        public abstract UsuarioModels Get(int id);
        public abstract UsuarioModels Add(UsuarioModels item);
        public abstract bool Update(UsuarioModels item);
        public abstract bool Remove(int id);

        #endregion
    }
}