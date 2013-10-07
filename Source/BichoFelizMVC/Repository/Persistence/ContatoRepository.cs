using System.Collections.Generic;
using System.Linq;
using BichoFelizMVC.Models;
using BichoFelizMVC.Repository.Base;

namespace BichoFelizMVC.Repository.Persistence {
  public class ContatoRepository : ContatoBase {
    private readonly BichoFelizDBEntities _dbContext = new BichoFelizDBEntities();

    public override IEnumerable<ContatoModels> Get() {
      IQueryable<ContatoModels> contatos = from c in _dbContext.CONTATOes
                                           select new ContatoModels {
                                             Status = c.STATUS,
                                             IdContato = c.IDCONTATO,
                                             Nome = c.NOME,
                                             Cidade = c.CIDADE,
                                             Cpf = c.CPF,
                                             Endereco = c.ENDERECO,
                                             Estado = c.ESTADO,
                                             Perfil = c.PERFIL,
                                             Bairro = c.BAIRRO
                                           };
      if (contatos.Any()) {
        return contatos.AsQueryable();
      }
      return null;
    }

    public override ContatoModels Get(int id) {
      IQueryable<ContatoModels> contatos = from c in _dbContext.CONTATOes
                                           where
                                             (c.IDCONTATO == id) && (c.STATUS == 1)
                                           select new ContatoModels {
                                             Status = c.STATUS,
                                             IdContato = c.IDCONTATO,
                                             Nome = c.NOME,
                                             Cidade = c.CIDADE,
                                             Cpf = c.CPF,
                                             Endereco = c.ENDERECO,
                                             Estado = c.ESTADO,
                                             Perfil = c.PERFIL,
                                             Bairro = c.BAIRRO
                                           };
      if (contatos.Any()) {
        return contatos.First();
      }
      return null;
    }

    public override bool Add(ContatoModels item) {
      var contato = new CONTATO {
        NOME = item.Nome,
        PERFIL = item.Perfil,
        BAIRRO = item.Bairro,
        CIDADE = item.Cidade,
        CPF = item.Cpf,
        ENDERECO = item.Endereco,
        ESTADO = item.Estado,
        STATUS = item.Status
      };

      _dbContext.CONTATOes.Add(contato);
      _dbContext.SaveChanges();

      return true;
    }

    public override bool Update(ContatoModels item) {
      CONTATO contato = _dbContext.CONTATOes.Find(item.IdContato);
      if (contato == null) {
        return false;
      }
      contato.NOME = item.Nome;
      contato.PERFIL = item.Perfil;
      contato.STATUS = item.Status;
      contato.CPF = item.Cpf;
      contato.ENDERECO = item.Endereco;
      contato.ESTADO = item.Estado;
      contato.BAIRRO = item.Bairro;
      contato.ESTADO = item.Estado;

      _dbContext.SaveChanges();
      return true;
    }

    public override bool Delete(int id) {
      CONTATO contato = _dbContext.CONTATOes.Find(id);
      if (contato == null) {
        return false;
      }
      contato.STATUS = 0;

      _dbContext.SaveChanges();
      return true;
    }
  }
}