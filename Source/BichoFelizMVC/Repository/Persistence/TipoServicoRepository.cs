using System.Collections.Generic;
using System.Linq;
using BichoFelizMVC.Models;
using BichoFelizMVC.Repository.Base;

namespace BichoFelizMVC.Repository.Persistence {
  public class TipoServicoRepository : TipoServicoBase {
    private readonly BichoFelizDBEntities _dbContext = new BichoFelizDBEntities();

    public override IEnumerable<TipoServicoModels> Get() {
      IQueryable<TipoServicoModels> tipoServicos = from t in _dbContext.TIPOSERVICOes
                                                   where 
                                                   (t.STATUS == 1)
                                                   select new TipoServicoModels {
                                                     TipoServico = t.NOME
                                                   };
      if (tipoServicos.Any()) {
        return tipoServicos.AsQueryable();
      }
      return null;
    }

    public override TipoServicoModels Get(int id) {
      IQueryable<TipoServicoModels> tipoServicos = from t in _dbContext.TIPOSERVICOes
                                                   where
                                                   (t.STATUS == 1)
                                                   select new TipoServicoModels {
                                                     TipoServico = t.NOME
                                                   };
      if (tipoServicos.Any()) {
        return tipoServicos.First();
      }
      return null;
    }

    public override bool Add(TipoServicoModels item) {
      var tipo = new TIPOSERVICO {
        NOME = item.TipoServico,
        STATUS = 1
      };
      _dbContext.TIPOSERVICOes.Add(tipo);
      _dbContext.SaveChanges();

      return true;
    }

    public override bool Update(TipoServicoModels item) {
      TIPOSERVICO tipoServico = _dbContext.TIPOSERVICOes.Find(item.IdTipoServico);
      if (tipoServico == null) {
        return false;
      }
      tipoServico.NOME = item.TipoServico;
      _dbContext.SaveChanges();

      return true;
    }

    public override bool Delete(int id) {
      TIPOSERVICO tipoServico = _dbContext.TIPOSERVICOes.Find(id);
      if (tipoServico == null) {
        return false;
      }
      tipoServico.STATUS = 0;
      _dbContext.SaveChanges();

      return true;
    }
  }
}