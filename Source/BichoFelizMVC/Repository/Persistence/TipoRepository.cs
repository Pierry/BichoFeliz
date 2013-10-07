using System.Collections.Generic;
using System.Linq;
using BichoFelizMVC.Models;
using BichoFelizMVC.Repository.Base;

namespace BichoFelizMVC.Repository.Persistence {
  public class TipoRepository : TipoBase {
    private readonly BichoFelizDBEntities _dbContext = new BichoFelizDBEntities();

    public override IEnumerable<TipoModels> Get() {
      IQueryable<TipoModels> tipo = from a in _dbContext.TIPOes
                                    where
                                      (a.STATUS == 1)
                                    select new TipoModels {
                                                            IdTipo = a.IDTIPO,
                                                            NomeTipo = a.NOME,
                                                          };
      if (tipo.Any()) {
        return tipo.AsQueryable();
      }
      return null;
    }

    public override TipoModels Get(int id) {
      IQueryable<TipoModels> tipo = from a in _dbContext.TIPOes
                                    where
                                      (a.STATUS == 1)
                                    select new TipoModels {
                                                            IdTipo = a.IDTIPO,
                                                            NomeTipo = a.NOME,
                                                          };
      if (tipo.Any()) {
        return tipo.First();
      }
      return null;
    }

    public override bool Add(TipoModels item) {
      var tipo = new TIPO {
                            NOME = item.NomeTipo,
                            STATUS = 1
                          };
      _dbContext.TIPOes.Add(tipo);
      _dbContext.SaveChanges();

      return true;
    }

    public override bool Update(TipoModels item) {
      TIPO tipo = _dbContext.TIPOes.Find(item.IdTipo);
      if (tipo == null) {
        return false;
      }
      tipo.NOME = item.NomeTipo;

      _dbContext.SaveChanges();
      return true;
    }

    public override bool Delete(int id) {
      TIPO tipo = _dbContext.TIPOes.Find(id);
      if (tipo == null) {
        return false;
      }
      tipo.STATUS = 0;

      _dbContext.SaveChanges();
      return true;
    }
  }
}