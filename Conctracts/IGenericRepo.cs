using _51_entity_lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.Contracts
{
    public interface IGenericRepo<T> where T : BaseEntity
    {

        ICollection<T> GetAll(bool isActive = true);        

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);

        void SoftDelete(int id);

        bool save();

        void UndoDelete(int id);

    }
}
