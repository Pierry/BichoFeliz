using System.Collections.Generic;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository.Base
{
    public abstract class UsuarioBase : ICrud<UsuarioModels>
    {
        #region ICrud<UsuarioModels> Members

        public abstract IEnumerable<UsuarioModels> Get();
        public abstract UsuarioModels Get(int id);
        public abstract bool Add(UsuarioModels item);
        public abstract bool Update(UsuarioModels item);
        public abstract bool Delete(int id);

        #endregion
    }
}