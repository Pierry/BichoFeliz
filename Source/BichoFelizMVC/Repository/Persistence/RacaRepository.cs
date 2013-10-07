using System.Collections.Generic;
using System.Linq;
using BichoFelizMVC.Models;
using BichoFelizMVC.Repository.Base;

namespace BichoFelizMVC.Repository.Persistence {
  public class RacaRepository : RacaBase {
    private readonly BichoFelizDBEntities _dbContext = new BichoFelizDBEntities();

    public override IEnumerable<RacaModels> Get() {
      IQueryable<RacaModels> racas = from r in _dbContext.RACAs
                                     join t in _dbContext.TIPOes on r.IDTIPO equals t.IDTIPO
                                     where (r.STATUS == 1) && (t.STATUS == 1)
                                     select new RacaModels {
                                       IdRaca = r.IDRACA,
                                       NomeRaca = r.NOME,
                                       Tipo = new TipoModels {
                                         IdTipo = t.IDTIPO,
                                         NomeTipo = t.NOME
                                       }
                                     };
      if (racas.Any()) {
        return racas.AsQueryable();
      }
      return null;
    }

    public override RacaModels Get(int id) {
      IQueryable<RacaModels> racas = from r in _dbContext.RACAs
                                     join t in _dbContext.TIPOes on r.IDTIPO equals t.IDTIPO
                                     where (r.STATUS == 1) && (t.STATUS == 1)
                                     select new RacaModels {
                                       IdRaca = r.IDRACA,
                                       NomeRaca = r.NOME,
                                       Tipo = new TipoModels {
                                         IdTipo = t.IDTIPO,
                                         NomeTipo = t.NOME
                                       }
                                     };
      if (racas.Any()) {
        return racas.First();
      }
      return null;
    }

    public override bool Add(RacaModels item) {
      var raca = new RACA {
        NOME = item.NomeRaca,
        STATUS = 1,
        IDTIPO = item.Tipo.IdTipo
      };
      _dbContext.RACAs.Add(raca);
      _dbContext.SaveChanges();

      return true;
    }

    public override bool Update(RacaModels item) {
      RACA raca = _dbContext.RACAs.Find(item.IdRaca);
      if (raca == null) {
        return false;
      }
      raca.IDTIPO = item.Tipo.IdTipo;
      raca.NOME = item.NomeRaca;
      _dbContext.SaveChanges();

      return true;
    }

    public override bool Delete(int id) {
      RACA raca = _dbContext.RACAs.Find(id);
      if (raca == null) {
        return false;
      }
      raca.STATUS = 0;
      _dbContext.SaveChanges();

      return true;
    }
  }
}