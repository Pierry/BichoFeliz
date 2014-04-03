using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using BichoFelizMVC.Controllers.Repository.Base;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository
{
    public class EmpresaRepository : EmpresaBase
    {
        private readonly BichoFelizMVCEntities _db = new BichoFelizMVCEntities();

        public override IEnumerable<EmpresaModels> Get()
        {
            var empresa = from e in _db.EMPRESA
                          select new EmpresaModels
                                 {
                                     IdEmpresa = e.IDEMPRESA,
                                     Cnpj = e.CNPJ,
                                     Nome = e.NOME
                                 };
            if (empresa.Any())
            {
                return empresa.AsQueryable();
            }
            return null;
        }

        public override EmpresaModels Get(int id)
        {
            throw new NotImplementedException();
        }

        public override EmpresaModels Add(EmpresaModels item)
        {
            var empresa = new EMPRESA
                              {
                                  CNPJ = item.Cnpj,
                                  NOME = item.Nome
                              };
            try
            {
                _db.EMPRESA.Add(empresa);
                _db.SaveChanges();
                return item;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return null;
            }
        }

        public override bool Update(EmpresaModels item)
        {
            var empresa = _db.EMPRESA.Find(item.IdEmpresa);
            if (empresa == null)
            {
                return false;
            }
            try
            {
                empresa.CNPJ = item.Cnpj;
                empresa.NOME = item.Nome;
                _db.EMPRESA.Remove(empresa);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return false;
            }
        }

        public override bool Remove(int id)
        {
            var empresa = _db.EMPRESA.Find(id);
            try
            {
                _db.EMPRESA.Remove(empresa);
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