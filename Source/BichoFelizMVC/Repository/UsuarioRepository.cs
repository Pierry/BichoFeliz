using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using BichoFelizMVC.Controllers.Repository.Base;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository
{
    public class UsuarioRepository : UsuarioBase
    {
        private readonly BichoFelizMVCEntities _db = new BichoFelizMVCEntities();

        public override IEnumerable<UsuarioModels> Get()
        {
            IQueryable<UsuarioModels> usuarios = from u in _db.USUARIO
                                                 select new UsuarioModels
                                                 {
                                                     CPF = u.CONTATO.CPF,
                                                     IdContato = u.IDCONTATO,
                                                     Email = u.EMAIL,
                                                     IdUsuario = u.IDUSUARIO,
                                                     Senha = u.SENHA
                                                 };
            if (usuarios.Any())
            {
                return usuarios.AsQueryable();
            }
            return null;
        }

        public ContatoModels LogIn(string usuario, string senha)
        {
            var user = from u in _db.USUARIO
                       join c in _db.CONTATO on u.IDCONTATO equals c.IDCONTATO
                       where
                           (u.EMAIL == usuario) && (u.SENHA == senha)
                       select new ContatoModels
                       {
                           IdContato = u.IDCONTATO,
                           IdEmpresa = c.IDEMPRESA
                       };
            if (user.Any())
            {
                return user.First();
            }
            return null;
        }

        public override UsuarioModels Get(int id)
        {
            UsuarioModels usuario = (from u in _db.USUARIO
                                     where
                                         (u.IDUSUARIO == id)
                                     select new UsuarioModels
                                     {
                                         CPF = u.CONTATO.CPF,
                                         IdContato = u.IDCONTATO,
                                         Email = u.EMAIL,
                                         IdUsuario = u.IDUSUARIO,
                                         Senha = u.SENHA
                                     }).First();
            if (usuario == null)
            {
                return null;
            }
            return usuario;
        }

        public override UsuarioModels Add(UsuarioModels item)
        {
            var usuario = new USUARIO
            {
                IDCONTATO = item.IdContato,
                EMAIL = item.Email,
                SENHA = item.Senha
            };
            try
            {
                _db.USUARIO.Add(usuario);
                _db.SaveChanges();
                return item;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return null;
            }
        }

        public override bool Update(UsuarioModels item)
        {
            USUARIO usuario = _db.USUARIO.Find(item.IdUsuario);
            if (usuario == null)
            {
                return false;
            }
            usuario.EMAIL = item.Email;
            usuario.IDCONTATO = item.IdContato;
            usuario.SENHA = item.Senha;

            try
            {
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return false;
                throw;
            }
        }

        public override bool Remove(int id)
        {
            var contato = _db.CONTATO.Find(id);
            var usuario = _db.USUARIO.FirstOrDefault(c => c.IDCONTATO == id);
            try
            {
                _db.CONTATO.Remove(contato);
                _db.USUARIO.Remove(usuario);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return false;
            }
        }
    }
}
