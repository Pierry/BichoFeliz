using System.Collections.Generic;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Controllers.Repository.Interfaces
{
    public interface ICrud<T>
    {
        IEnumerable<T> Get();

        T Get(int id);

        T Add(T item);

        bool Update(T item);

        bool Remove(int id);
    }
}