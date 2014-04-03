using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using BichoFelizMVC.Controllers.Repository.Base;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository
{
    public class ServicoRepository : ServicoBase
    {
        private readonly BichoFelizMVCEntities _db = new BichoFelizMVCEntities();

        public IEnumerable<TipoServicoModels> GetTipos()
        {
            IQueryable<TipoServicoModels> tipos = from t in _db.TIPOSERVICO
                                                  select new TipoServicoModels
                                                         {
                                                             IdTpServico = t.IDTIPOSERVICO,
                                                             Nome = t.NOME
                                                         };
            if (tipos.Any())
            {
                return tipos.AsQueryable();
            }
            return null;
        }

        public TipoServicoModels AddTipo(TipoServicoModels item)
        {
            var tipo = new TIPOSERVICO
                       {
                           NOME = item.Nome
                       };
            try
            {
                _db.TIPOSERVICO.Add(tipo);
                _db.SaveChanges();
                return item;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return null;
            }
        }

        public bool RemoveTipo(int id)
        {
            TIPOSERVICO tipo = _db.TIPOSERVICO.Find(id);
            try
            {
                _db.TIPOSERVICO.Remove(tipo);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return false;
            }
        }

        public override IEnumerable<ServicoModels> Get()
        {
            return null;
        }

        public IEnumerable<ServicoAnimalModel> GetServicos()
        {
            IQueryable<ServicoAnimalModel> servicos = from s in _db.SERVICO
                join c in _db.CONTATO on s.IDCONTATO equals c.IDCONTATO
                join a in _db.ANIMAL on s.IDANIMAL equals a.IDANIMAL
                join t in _db.TIPOSERVICO on s.IDTIPOSERVICO equals t.IDTIPOSERVICO
                where (s.STATUS == 1)
                select new ServicoAnimalModel
                       {
                           Animal = a.NOME,
                           DataHora = s.DATAHORA,
                           IdServico = s.IDSERVICO,
                           NomeContato = c.NOME,
                           IdAnimal = a.IDANIMAL,
                           IdContato = c.IDCONTATO,
                           IdTipoServico = t.IDTIPOSERVICO,
                           Periodo = s.PERIODO,
                           Status = s.STATUS,
                           Tipo = t.NOME
                       };
            if (servicos.Any())
            {
                return servicos.AsQueryable();
            }
            return null;
        }


        public override ServicoModels Get(int id)
        {
            return null;
        }

        public ServicoAnimalModel GetServico(int id)
        {
            IQueryable<ServicoAnimalModel> servicos = from s in _db.SERVICO
                                                      join c in _db.CONTATO on s.IDCONTATO equals c.IDCONTATO
                                                      join a in _db.ANIMAL on s.IDANIMAL equals a.IDANIMAL
                                                      join t in _db.TIPOSERVICO on s.IDTIPOSERVICO equals t.IDTIPOSERVICO
                                                      where (s.STATUS == 1 && s.IDSERVICO == id)
                                                      select new ServicoAnimalModel
                                                      {
                                                          Animal = a.NOME,
                                                          DataHora = s.DATAHORA,
                                                          IdServico = s.IDSERVICO,
                                                          NomeContato = c.NOME,
                                                          IdAnimal = a.IDANIMAL,
                                                          IdContato = c.IDCONTATO,
                                                          IdTipoServico = t.IDTIPOSERVICO,
                                                          Periodo = s.PERIODO,
                                                          Status = s.STATUS,
                                                          Tipo = t.NOME
                                                      };
            if (servicos.Any())
            {
                return servicos.First();
            }
            return null;
        }

        public override ServicoModels Add(ServicoModels item)
        {
            var servico = new SERVICO
            {
                IDCONTATO = item.IdContato,
                DATAHORA = item.DataHora,
                PERIODO = item.Periodo,
                STATUS = item.Status,
                IDTIPOSERVICO = item.IdTipoServico,
                IDANIMAL = item.IdAnimal
            };
            try
            {
                _db.SERVICO.Add(servico);
                _db.SaveChanges();
                item.IdServico = servico.IDSERVICO;
                return item;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return null;
            }
        }

        public ServicoAnimalModel AddServico(ServicoModels item)
        {
            var servico = new SERVICO
            {
                IDCONTATO = item.IdContato,
                DATAHORA = item.DataHora,
                PERIODO = item.Periodo,
                STATUS = item.Status,
                IDTIPOSERVICO = item.IdTipoServico,
                IDANIMAL = item.IdAnimal,
            };
            try
            {
                _db.SERVICO.Add(servico);
                _db.SaveChanges();
                var servicoModel = GetServico(servico.IDSERVICO);
                if (servicoModel == null)
                {
                    return null;
                }
                return servicoModel;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return null;
            }
        }

        public override bool Update(ServicoModels item)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(int id)
        {
            var servico = _db.SERVICO.Find(id);
            try
            {
                _db.SERVICO.Remove(servico);
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