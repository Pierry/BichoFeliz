using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BichoFelizMVC.Models;
using BichoFelizMVC.Repository.Base;

namespace BichoFelizMVC.Repository.Persistence {
  public class UsuarioRepository : UsuarioBase {

    private readonly BichoFelizDBEntities _dbContext = new BichoFelizDBEntities();

    public override IEnumerable<UsuarioModels> Get() {
      var usuario = from u in _dbContext.USUARIOs
                    join c in _dbContext.CONTATOes on u.IDCONTATO equals c.IDCONTATO
                    select new UsuarioModels {
                      Email = u.EMAIL,
                      IdContato = u.IDCONTATO,
                      IdUsuario = u.IDUSUARIO,
                      Senha = u.SENHA,
                      Contato = new ContatoModels {
                        Bairro = c.BAIRRO,
                        Status = c.STATUS,
                        IdContato = c.IDCONTATO,
                        Nome = c.NOME,
                        Cidade = c.CIDADE,
                        Cpf = c.CPF,
                        Endereco = c.ENDERECO,
                        Estado = c.ESTADO,
                        Perfil = c.PERFIL
                      }
                    };
      if (usuario.Any()) {
        return usuario.AsQueryable();
      }
      return null;
    }

    public override UsuarioModels Get(int id) {
      var usuario = from u in _dbContext.USUARIOs
                    join c in _dbContext.CONTATOes on u.IDCONTATO equals c.IDCONTATO
                    select new UsuarioModels {
                      Email = u.EMAIL,
                      IdContato = u.IDCONTATO,
                      IdUsuario = u.IDUSUARIO,
                      Senha = u.SENHA,
                      Contato = new ContatoModels {
                        Bairro = c.BAIRRO,
                        Status = c.STATUS,
                        IdContato = c.IDCONTATO,
                        Nome = c.NOME,
                        Cidade = c.CIDADE,
                        Cpf = c.CPF,
                        Endereco = c.ENDERECO,
                        Estado = c.ESTADO,
                        Perfil = c.PERFIL
                      }
                    };
      if (usuario.Any()) {
        return usuario.First();
      }
      return null;
    }

    public override bool Add(UsuarioModels item) {
      var usuario = new USUARIO {
        IDCONTATO = item.IdContato,
        EMAIL = item.Email,
        SENHA = item.Senha,
        STATUS = 1
      };
      _dbContext.USUARIOs.Add(usuario);
      _dbContext.SaveChanges();
      return true;
    }

    public override bool Update(UsuarioModels item) {
      var usuario = _dbContext.USUARIOs.Find(item.IdUsuario);
      if (usuario == null) {
        return false;
      }

      usuario.IDCONTATO = item.IdContato;
      usuario.EMAIL = item.Email;
      usuario.SENHA = item.Senha;
      usuario.STATUS = item.Status;

      _dbContext.SaveChanges();
      return true;
    }

    public override bool Delete(int id) {
      var usuario = _dbContext.USUARIOs.Find(id);
      if (usuario == null) {
        return false;
      }

      usuario.STATUS = 0;

      _dbContext.SaveChanges();
      return true;
    }
  }
}