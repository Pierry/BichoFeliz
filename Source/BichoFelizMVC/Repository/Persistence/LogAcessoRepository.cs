using System.Collections.Generic;
using System.Linq;
using BichoFelizMVC.Models;
using BichoFelizMVC.Repository.Base;

namespace BichoFelizMVC.Repository.Persistence {
  public class LogAcessoRepository : LogAcessoBase {
    private readonly BichoFelizDBEntities _dbContext = new BichoFelizDBEntities();

    public override IEnumerable<LogAcessoModels> Get() {
      IQueryable<LogAcessoModels> logs = from l in _dbContext.LOGACESSOes
                                         join u in _dbContext.USUARIOs on l.IDUSUARIO equals u.IDUSUARIO
                                         select new LogAcessoModels {
                                           Token = l.TOKEN,
                                           DataHora = l.DATAHORA,
                                           IdToken = l.IDTOKEN,
                                           IdUsuario = l.IDUSUARIO,
                                           Status = l.STATUS,
                                           Usuario = new UsuarioModels {
                                             IdContato = u.IDCONTATO,
                                             IdUsuario = u.IDUSUARIO,
                                             Email = u.EMAIL
                                           }
                                         };
      if (logs.Any()) {
        return logs.AsQueryable();
      }
      return null;
    }

    public override LogAcessoModels Get(int id) {
      IQueryable<LogAcessoModels> logs = from l in _dbContext.LOGACESSOes
                                         join u in _dbContext.USUARIOs on l.IDUSUARIO equals u.IDUSUARIO
                                         where
                                         (l.IDTOKEN == id)
                                         select new LogAcessoModels {
                                           Token = l.TOKEN,
                                           DataHora = l.DATAHORA,
                                           IdToken = l.IDTOKEN,
                                           IdUsuario = l.IDUSUARIO,
                                           Status = l.STATUS,
                                           Usuario = new UsuarioModels {
                                             IdContato = u.IDCONTATO,
                                             IdUsuario = u.IDUSUARIO,
                                             Email = u.EMAIL
                                           }
                                         };
      if (logs.Any()) {
        return logs.First();
      }
      return null;
    }

    public override bool Add(LogAcessoModels item) {
      var log = new LOGACESSO {
        DATAHORA = item.DataHora,
        IDUSUARIO = item.IdUsuario,
        TOKEN = item.Token,
        STATUS = item.Status
      };
      _dbContext.LOGACESSOes.Add(log);
      _dbContext.SaveChanges();

      return true;
    }

    public override bool Update(LogAcessoModels item) {
      LOGACESSO log = _dbContext.LOGACESSOes.Find(item.IdToken);
      if (log == null) {
        return false;
      }
      log.DATAHORA = item.DataHora;
      log.TOKEN = item.Token;
      log.IDUSUARIO = item.IdUsuario;
      log.STATUS = item.Status;

      _dbContext.SaveChanges();

      return true;
    }

    public override bool Delete(int id) {
      LOGACESSO log = _dbContext.LOGACESSOes.Find(id);
      if (log == null) {
        return false;
      }
      log.STATUS = 0;

      _dbContext.SaveChanges();
      return true;
    }
  }
}