using _51_entity_lab2.Contexts;
using _51_entity_lab2.Contracts;
using _51_entity_lab2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.concretes
{
    public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
    {
        public AppDbContext _contex{ get; set; }
        public GenericRepo(AppDbContext context)
        {
            _contex = context;
        }
        public void Add(T entity)
        {
            _contex.Add(entity);
        }

        public void Delete(int id)
        {
            _contex.Remove(GetById(id));
        }

        public ICollection<T> GetAll(bool isActive = true)
        {
            if (isActive)
            {
                return _contex.Set<T>().Where(x => x.Status == Enums.EntityStatus.aktif).ToList();

            }
            else
                return _contex.Set<T>().Where(x => x.Status == Enums.EntityStatus.pasif).ToList();
        }

        public T GetById(int id)
        {
            return _contex.Set<T>().Find(id);
        }

        public bool save()
        {
            return _contex.SaveChanges() > 0 ? true: false; 
        }

        public void SoftDelete(int id)
        {
            GetById(id).setpasif();
            
        }

        public void Update(T entity)
        {
            _contex.Update(entity);
        }

        public void UndoDelete(int id)
        {
            GetById(id).setactive();
        }
    }
}
