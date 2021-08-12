using Crm.DataAccessLayer;
using Crm.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crm.DataAccessLayer.EntityFramework
{
    public class Repository<T> : RepositoryBase, IRepository<T> where T : class // T new lenebilen bir tip olmalıdır.
    {
        //private DatabaseContext db = new DatabaseContext(); // her seferinde newlendiğinde ortak kullanımda hata verıyor.Singleton kullanbk.
        private DbSet<T> _objectSet; // Gelen objeni set değerini atayacagız.
        public Repository()
        {
            // Her methodda gelen T tipinin set ini bulmak için db.Set<T>() kullanıyoduk. bunu constructor a tanımladık.
            _objectSet = context.Set<T>();
        }
        public List<T> List()
        {
            // db.Set<T>() //  GELEN OBJECTİNİN HANGİ CLASS YANI HANGI DATASET(TABLO) OLDUĞUNU BULUR.
            //return db.Set<T>().ToList();
            return _objectSet.ToList();
        }
        /*
         * 1. YOL -> ToList ile sql e sorgu atılır. List dönünce işlem bitmiş olur. Yani dönen listede son 3 kayıt veya şuna göre sırala vb kullanamayız.
                     bunun için 2. yol olarak IQuaryable kullanmamız gerekiyor. Gelen sonuca .ToList dememiz gerekiyor.
        */
        public List<T> List(Expression<Func<T,bool>> where)
        {
            return _objectSet.Where(where).ToList(); // ToList diyince sorgu bitmiş liste dönmüş oluyor.
        }

        /* 2. YOL
        public IQueryable<T> List(Expression<Func<T,bool>> where)
        {
            return _objectSet.Where(where);
        }
        */

        public int Insert(T obj)
        {
            //db.Set<T>().Add(obj);
            _objectSet.Add(obj);
            return Save();
        }
        public int Update(T obj)
        {
            return Save();
        }
        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }
        public T Find(Expression<Func<T,bool>> where)
        {
            return _objectSet.FirstOrDefault(where); // nesneyi bulursa döndürür bulamazsa NULL döner
        }
        public int Save()
        {
          return context.SaveChanges();
        }
    }
}
