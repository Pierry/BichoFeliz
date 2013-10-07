using System.Collections.Generic;
using System.Linq;
using BichoFelizMVC.Models;
using BichoFelizMVC.Repository.Base;

namespace BichoFelizMVC.Repository.Persistence {
  public class AnimalRepository : AnimalBase {
    private readonly BichoFelizDBEntities _dbContext = new BichoFelizDBEntities();

    public override IEnumerable<AnimalModels> Get() {
      IQueryable<AnimalModels> animais = from a in _dbContext.ANIMALs
                                         join r in _dbContext.RACAs on a.IDRACA equals r.IDRACA
                                         join t in _dbContext.TIPOes on r.IDTIPO equals t.IDTIPO
                                         join c in _dbContext.CONTATOes on a.IDCONTATO equals c.IDCONTATO
                                         select new AnimalModels {
                                           IdAnimal = a.IDANIMAL,
                                           NomeAnimal = a.NOME,
                                           Raca = new RacaModels {
                                             IdRaca = r.IDRACA,
                                             NomeRaca = r.NOME,
                                             Tipo = new TipoModels {
                                               IdTipo = t.IDTIPO,
                                               NomeTipo = t.NOME
                                             }
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
                                           }
                                         };
      if (animais.Any()) {
        return animais.AsQueryable();
      }
      return null;
    }

    public override AnimalModels Get(int id) {
      IQueryable<AnimalModels> animais = from a in _dbContext.ANIMALs
                                         join r in _dbContext.RACAs on a.IDRACA equals r.IDRACA
                                         join t in _dbContext.TIPOes on r.IDTIPO equals t.IDTIPO
                                         join c in _dbContext.CONTATOes on a.IDCONTATO equals c.IDCONTATO
                                         where 
                                         (a.IDANIMAL == id)
                                         select new AnimalModels {
                                           IdAnimal = a.IDANIMAL,
                                           NomeAnimal = a.NOME,
                                           Raca = new RacaModels {
                                             IdRaca = r.IDRACA,
                                             NomeRaca = r.NOME,
                                             Tipo = new TipoModels {
                                               IdTipo = t.IDTIPO,
                                               NomeTipo = t.NOME
                                             }
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
                                           }
                                         };
      if (animais.Any()) {
        return animais.First();
      }
      return null;
    }

    public override bool Add(AnimalModels item) {
      var animal = new ANIMAL {
        NOME = item.NomeAnimal,
        IDCONTATO = item.IdContato,
        STATUS = 1,
        IDRACA = item.Raca.IdRaca
      };
      _dbContext.ANIMALs.Add(animal);
      _dbContext.SaveChanges();

      return true;
    }

    public override bool Update(AnimalModels item) {
      ANIMAL animal = _dbContext.ANIMALs.Find(item.IdAnimal);
      if (animal == null) {
        return false;
      }
      animal.IDCONTATO = item.IdContato;
      animal.IDRACA = item.Raca.IdRaca;
      animal.NOME = item.NomeAnimal;

      _dbContext.SaveChanges();
      return true;
    }

    public override bool Delete(int id) {
      ANIMAL animal = _dbContext.ANIMALs.Find(id);
      if (animal == null) {
        return false;
      }
      animal.STATUS = 0;

      _dbContext.SaveChanges();
      return true;
    }
  }
}