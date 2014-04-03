using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using BichoFelizMVC.Controllers.Repository.Base;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository
{
    public class ContatoRepository : ContatoBase
    {
        private readonly BichoFelizMVCEntities _db = new BichoFelizMVCEntities();

        public override IEnumerable<ContatoModels> Get()
        {
            var usuarios = from u in _db.USUARIO
                           join c in _db.CONTATO on u.IDCONTATO equals c.IDCONTATO
                           select new ContatoModels
                               {
                                   IdContato = c.IDCONTATO,
                                   Bairro = c.BAIRRO,
                                   Cidade = c.CIDADE,
                                   Cpf = c.CPF,
                                   Endereco = c.ENDERECO,
                                   Estado = c.ESTADO,
                                   IdEmpresa = c.IDEMPRESA,
                                   NomeContato = c.NOME,
                                   Perfil = c.PERFIL,
                                   Status = c.STATUS
                               };
            if (usuarios.Any())
            {
                return usuarios;
            }
            return null;
        }

        public override ContatoModels Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistrarUsuarioViewModel> GetUsuarios(int idEmpresa)
        {
            var usuarios = from u in _db.USUARIO
                           join c in _db.CONTATO on u.IDCONTATO equals c.IDCONTATO
                           where
                               (c.IDEMPRESA == idEmpresa) && (c.PERFIL == 5)
                           select new RegistrarUsuarioViewModel
                                  {
                                      Email = u.EMAIL,
                                      Senha = u.SENHA,
                                      IdContato = c.IDCONTATO,
                                      IdUsuario = u.IDUSUARIO,
                                      Bairro = c.BAIRRO,
                                      Cidade = c.CIDADE,
                                      Cpf = c.CPF,
                                      Endereco = c.ENDERECO,
                                      Estado = c.ESTADO,
                                      IdEmpresa = c.IDEMPRESA,
                                      NomeContato = c.NOME,
                                      Perfil = c.PERFIL,
                                      Status = c.STATUS
                                  };
            if (usuarios.Any())
            {
                return usuarios;
            }
            return null;
        }

        public IEnumerable<RegistrarUsuarioViewModel> GetClientes()
        {
            var clientes = from c in _db.CONTATO
                           where
                           (c.STATUS == 1) && (c.PERFIL == 1)
                           select new RegistrarUsuarioViewModel
                           {
                               IdContato = c.IDCONTATO,
                               Bairro = c.BAIRRO,
                               Cidade = c.CIDADE,
                               Cpf = c.CPF,
                               Endereco = c.ENDERECO,
                               IdEmpresa = c.IDEMPRESA,
                               NomeContato = c.NOME,
                               Perfil = c.PERFIL,
                               Status = c.STATUS
                           };
            if (clientes.Any())
            {
                return clientes;
            }
            return null;
        }

        public override ContatoModels Add(ContatoModels item)
        {
            var contato = new CONTATO
                              {
                                  NOME = item.NomeContato,
                                  CPF = item.Cpf,
                                  IDEMPRESA = item.IdEmpresa,
                                  ENDERECO = item.Endereco,
                                  BAIRRO = item.Bairro,
                                  CIDADE = item.Cidade,
                                  ESTADO = item.Estado,
                                  STATUS = 1,
                                  PERFIL = item.Perfil
                              };
            try
            {
                _db.CONTATO.Add(contato);
                _db.SaveChanges();
                item.IdContato = contato.IDCONTATO;
                return item;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return null;
            }
        }

        public ContatoModels AddCliente(ContatoModels item)
        {
            var contato = new CONTATO
            {
                NOME = item.NomeContato,
                CPF = item.Cpf,
                IDEMPRESA = item.IdEmpresa,
                ENDERECO = item.Endereco,
                BAIRRO = item.Bairro,
                CIDADE = item.Cidade,
                STATUS = 1,
                PERFIL = 1
            };
            try
            {
                _db.CONTATO.Add(contato);
                _db.SaveChanges();
                item.IdContato = contato.IDCONTATO;
                return item;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return null;
            }
        }

        public override bool Update(ContatoModels item)
        {
            var contato = _db.CONTATO.Find(item.IdContato);
            if (contato == null)
            {
                return false;
            }
            contato.IDEMPRESA = item.IdEmpresa;
            contato.NOME = item.NomeContato;
            contato.ENDERECO = item.Endereco;
            contato.ESTADO = item.Estado;
            contato.BAIRRO = item.Bairro;
            contato.CIDADE = item.Cidade;
            contato.ESTADO = item.Estado;

            try
            {
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return false;
                throw;
            }
        }

        public override bool Remove(int id)
        {
            var contato = _db.CONTATO.Find(id);
            try
            {
                _db.CONTATO.Remove(contato);
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