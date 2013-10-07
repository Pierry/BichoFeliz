using System.Collections.Generic;

namespace BichoFelizMVC.Repository
{
    public interface ICrud<T>
    {
        IEnumerable<T> Get();

        T Get(int id);

        bool Add(T item);

        bool Update(T item);

        bool Delete(int id);

    }
}