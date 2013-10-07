using System.Collections.Generic;
using System.Linq;
using BichoFelizMVC.Models;
using BichoFelizMVC.Repository.Base;

namespace BichoFelizMVC.Repository.Persistence {
  public class ServicoRepository : ServicoBase {

    private readonly BichoFelizDBEntities _dbContext = new BichoFelizDBEntities();

    public override IEnumerable<ServicoModels> Get() {
      var servicos = from t in _dbContext.TIPOSERVICOes
                     join s in _dbContext.SERVICOes on t.IDTIPOSERVICO equals s.IDTIPOSERVICO
                     join c in _dbContext.CONTATOes on s.IDCONTATO equals c.IDCONTATO
                     join a in _dbContext.ANIMALs on s.IDANIMAL equals a.IDANIMAL
                     join r in _dbContext.RACAs on a.IDRACA equals r.IDRACA
                     join tt in _dbContext.TIPOes on r.IDTIPO equals tt.IDTIPO
                     select new ServicoModels {
                       DataHora = s.DATAHORA,
                       Periodo = s.PERIODO,
                       Situacao = s.PERIODO,
                       IdServico = s.IDSERVICO,
                       TipoServico = new TipoServicoModels {
                         IdTipoServico = t.IDTIPOSERVICO,
                         Status = t.STATUS,
                         TipoServico = t.NOME
                       },
                       Contato = new ContatoModels {
                         Status = c.STATUS,
                         IdContato = c.IDCONTATO,
                         Nome = c.NOME,
                         Cidade = c.CIDADE,
                         Cpf = c.CPF,
                         Endereco = c.ENDERECO,
                         Estado = c.ESTADO,
                         Perfil = c.PERFIL,
                         Bairro = c.BAIRRO
                       },
                       Animal = new AnimalModels {
                         IdAnimal = a.IDANIMAL,
                         NomeAnimal = a.NOME,
                         Raca = new RacaModels {
                           IdRaca = r.IDRACA,
                           NomeRaca = r.NOME,
                           Tipo = new TipoModels {
                             IdTipo = tt.IDTIPO,
                             NomeTipo = tt.NOME
                           }
                         }
                       }
                     };
      if (servicos.Any()) {
        return servicos.AsQueryable();
      }
      return null;
    }

    public override ServicoModels Get(int id) {
      var servicos = from t in _dbContext.TIPOSERVICOes
                     join s in _dbContext.SERVICOes on t.IDTIPOSERVICO equals s.IDTIPOSERVICO
                     join c in _dbContext.CONTATOes on s.IDCONTATO equals c.IDCONTATO
                     join a in _dbContext.ANIMALs on s.IDANIMAL equals a.IDANIMAL
                     join r in _dbContext.RACAs on a.IDRACA equals r.IDRACA
                     join tt in _dbContext.TIPOes on r.IDTIPO equals tt.IDTIPO
                     select new ServicoModels {
                       DataHora = s.DATAHORA,
                       Periodo = s.PERIODO,
                       Situacao = s.PERIODO,
                       IdServico = s.IDSERVICO,
                       TipoServico = new TipoServicoModels {
                         IdTipoServico = t.IDTIPOSERVICO,
                         Status = t.STATUS,
                         TipoServico = t.NOME
                       },
                       Contato = new ContatoModels {
                         Status = c.STATUS,
                         IdContato = c.IDCONTATO,
                         Nome = c.NOME,
                         Cidade = c.CIDADE,
                         Cpf = c.CPF,
                         Endereco = c.ENDERECO,
                         Estado = c.ESTADO,
                         Perfil = c.PERFIL,
                         Bairro = c.BAIRRO
                       },
                       Animal = new AnimalModels {
                         IdAnimal = a.IDANIMAL,
                         NomeAnimal = a.NOME,
                         Raca = new RacaModels {
                           IdRaca = r.IDRACA,
                           NomeRaca = r.NOME,
                           Tipo = new TipoModels {
                             IdTipo = tt.IDTIPO,
                             NomeTipo = tt.NOME
                           }
                         }
                       }
                     };
      if (servicos.Any()) {
        return servicos.First();
      }
      return null;
    }

    public override bool Add(ServicoModels item) {
      var servico = new SERVICO {
        IDTIPOSERVICO = item.TipoServico.IdTipoServico,
        IDCONTATO = item.Contato.IdContato,
        IDANIMAL = item.Animal.IdAnimal,
        DATAHORA = item.DataHora,
        PERIODO = item.Periodo,
        SITUACAO = item.Situacao
      };
      _dbContext.SERVICOes.Add(servico);
      _dbContext.SaveChanges();

      return true;
    }

    public override bool Update(ServicoModels item) {
      var servico = _dbContext.SERVICOes.Find(item.IdServico);
      if (servico == null) {
        return true;
      }

      servico.IDTIPOSERVICO = item.TipoServico.IdTipoServico;
      servico.IDCONTATO = item.Contato.IdContato;
      servico.IDANIMAL = item.Animal.IdAnimal;
      servico.DATAHORA = item.DataHora;
      servico.PERIODO = item.Periodo;
      servico.SITUACAO = item.Situacao;

      _dbContext.SaveChanges();
      return true;
    }

    public override bool Delete(int id) {
      var servico = _dbContext.SERVICOes.Find(id);
      if (servico == null) {
        return true;
      }

      servico.SITUACAO = 0;

      _dbContext.SaveChanges();
      return true;
    }
  }
}