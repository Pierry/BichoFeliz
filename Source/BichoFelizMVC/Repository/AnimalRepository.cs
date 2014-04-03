using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using BichoFelizMVC.Controllers.Repository.Base;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository
{
    public class AnimalRepository : AnimalBase
    {
        private readonly BichoFelizMVCEntities _db = new BichoFelizMVCEntities();

        public override IEnumerable<AnimalModels> Get()
        {
            IQueryable<AnimalModels> animais = from a in _db.ANIMAL
                                               select new AnimalModels
                                                          {
                                                              IdAnimal = a.IDANIMAL,
                                                              IdTipo = a.IDTIPO,
                                                              Nome = a.NOME,
                                                              CPF = a.CONTATO.CPF,
                                                              IdContato = a.IDCONTATO
                                                          };
            if (animais.Any())
            {
                return animais.AsQueryable();
            }
            return null;
        }

        public IEnumerable<AnimalViewModel> GetAnimais()
        {
            IQueryable<AnimalViewModel> animais = from a in _db.ANIMAL
                                               select new AnimalViewModel
                                               {
                                                   IdAnimal = a.IDANIMAL,
                                                   IdTipo = a.IDTIPO,
                                                   Nome = a.NOME,
                                                   IdEmpresa = a.CONTATO.IDEMPRESA,
                                                   NomeCliente = a.CONTATO.NOME,
                                                   IdContato = a.IDCONTATO
                                               };
            if (animais.Any())
            {
                return animais.AsQueryable();
            }
            return null;
        }
        
        public IEnumerable<TipoModels> GetTipos()
        {
            var tipos = from t in _db.TIPO
                select new TipoModels
                       {
                           Nome = t.NOME
                       };
            if (tipos.Any())
            {
                return tipos.AsQueryable();
            }
            return null;
        }

        public override AnimalModels Get(int id)
        {
            return null;
        }

        public IEnumerable<AnimalModels> GetAnimais(int idCliente)
        {
            IQueryable<AnimalModels> animal = from a in _db.ANIMAL
                                              where
                                                  (a.IDCONTATO == idCliente)
                                              select new AnimalModels
                                                         {
                                                             IdAnimal = a.IDANIMAL,
                                                             IdTipo = a.IDTIPO,
                                                             Nome = a.NOME,
                                                             CPF = a.CONTATO.CPF,
                                                             IdContato = a.IDCONTATO
                                                         };
            if (animal.Any())
            {
                return animal.AsQueryable();
            }
            return null;
        }

        public override AnimalModels Add(AnimalModels item)
        {
            var animal = new ANIMAL
                             {
                                 NOME = item.Nome,
                                 IDCONTATO = item.IdContato,
                                 IDTIPO = item.IdTipo
                             };
            try
            {
                _db.ANIMAL.Add(animal);
                _db.SaveChanges();
                return item;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return null;
            }
        }

        public override bool Update(AnimalModels item)
        {
            ANIMAL animal = _db.ANIMAL.Find(item.IdAnimal);
            if (animal == null)
            {
                return false;
            }

            animal.IDCONTATO = item.IdContato;
            animal.IDTIPO = item.IdTipo;
            animal.NOME = item.Nome;

            try
            {
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
            var animal = _db.ANIMAL.Find(id);
            try
            {
                _db.ANIMAL.Remove(animal);
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