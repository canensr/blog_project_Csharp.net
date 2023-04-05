using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context c = new Context();     // Sınıfların türetildiği sınıfa erişim sağlayabilmemiz için Context sınıfından bir tane c nesnesi türetmemiz gerekiyor.
        DbSet<T> _object;             // _object dışarıdan gönderilen değerler.

        public Repository()
        {
           _object = c.Set<T>();      // Göndermiş olduğum sınıfı _object ismindeki field'ıma atayacaksın.
        }

        public int Delete(T p)
        {
            _object.Remove(p);
            return c.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _object.FirstOrDefault(where);
        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public int Insert(T p)
        {
            _object.Add(p);
            return c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public int Update(T p)
        {
            return c.SaveChanges(); 
        }
    }
}
