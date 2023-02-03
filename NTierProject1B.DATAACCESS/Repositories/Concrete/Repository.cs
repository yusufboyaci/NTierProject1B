using NTierProject1B.CORE.Entity;
using NTierProject1B.CORE.Enum;
using NTierProject1B.DATAACCESS.Context;
using NTierProject1B.DATAACCESS.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NTierProject1B.DATAACCESS.Repositories.Concrete
{
    public class Repository<T>: IRepository<T> where T : CoreEntity
    {

        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Durumu false olan yani silinmiş olan kaydı aktif hale getiren metottur.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Activate(Guid id)
        {
            T activated = GetById(id);
            activated.Status = Status.Active;
            return Update(activated);
        }
        /// <summary>
        /// Database e nesne eklemeyi sağlayan metottur.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(T entity)
        {
            entity.Status = Status.Active;
            _context.Set<T>().Add(entity);
            return Save() > 0;
        }
        /// <summary>
        /// Liste içerisindeki nesnelerin hepsini database e ekleyen metottur.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool Add(List<T> entities)
        {
            entities.ForEach(x => x.Status = Status.Active);
            _context.Set<T>().AddRange(entities);
            return Save() > 0;
        }
        /// <summary>
        /// Nesnelerin bulunduğu diziden aranan nesnenin bulunup bulunmadığı bilgisini veren metottur.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Any(exp);
        }
        /// <summary>
        /// Durumu true olan aktif nesneleri getiren mettotur.
        /// </summary>
        /// <returns></returns>
        public List<T> GetActives()
        {
            return _context.Set<T>().Where(x => x.Status == Status.Active).ToList();
        }
        /// <summary>
        /// Bütün nesneleri getiren metottur.
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        /// <summary>
        /// Bir filitre expression nuna göre ilgili nesneyi getiren metottur.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).FirstOrDefault() ?? throw new Exception("Böyle bir nesne yoktur");
        }
        /// <summary>
        /// Id si verilen nesne nin kendisini getiren metottur.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id) ?? throw new Exception("Böyle bir nesne yoktur");
        }
        /// <summary>
        /// Bir filitre expression nuna göre ilgili nesne listesini (nesneleri) getiren metottur.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public List<T> GetDefaults(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }
        /// <summary>
        /// Nesnenin durumunu false yapan yani aktifliğini pasif e çeken metottur.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Remove(T entity)
        {
            entity.Status = Status.Deleted;
            return Update(entity);
        }
        /// <summary>
        /// Nesnenin durumunu false yapan yani aktifliğini pasif e çeken metottur.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remove(Guid id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    T deleted = GetById(id);
                    deleted.Status = Status.Deleted;
                    Update(deleted);
                    ts.Complete();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Nesnelerin durumunu false yapan yani aktifliğini pasif e çeken metottur.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public bool RemoveAll(Expression<Func<T, bool>> exp)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                List<T> collection = GetDefaults(exp);
                int count = 0;
                collection.ForEach(item =>
                {
                    item.Status = Status.Deleted;
                    bool result = Update(item);
                    if (result)
                    {
                        count++;
                    }
                });
                if (collection.Count == count)
                {
                    ts.Complete();
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Nesnelerin database e yüklenmesini sağlayan metottur.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return _context.SaveChanges();
        }
        /// <summary>
        /// Nesneleri güncelleyen metottur.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                return Save() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
