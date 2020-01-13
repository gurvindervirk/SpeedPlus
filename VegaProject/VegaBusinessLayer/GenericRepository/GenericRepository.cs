using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataContext;
namespace VegaBusinessLayer
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public VegaContext _context = null;
       
        private DbSet<T> table = null;
        public GenericRepository(bool createProxy = true)
        {
            this._context = new VegaContext();
            table = _context.Set<T>();
        }
        public GenericRepository(VegaContext _context)
        {
             this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using DataContext;
//using VegaBusinessLayer.NonGenricRepositories;
//namespace VegaBusinessLayer
//{
//    public class GenericRepository<T> : IGenericRepository<T> where T : class
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        public GenericRepository(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }
//        public IEnumerable<T> GetAll()
//        {
//            return _unitOfWork.Context.Set<T>().AsEnumerable<T>();
//         }
//        public T GetById(object id)
//        {
//            return _unitOfWork.Context.Set<T>().Find(id);
//         }
//        public void Insert(T obj)
//        {
//           _unitOfWork.Context.Set<T>().Add(obj);
//        }
//        public void Update(T obj)
//        {
//            _unitOfWork.Context.Entry(obj).State = EntityState.Modified;
//            _unitOfWork.Context.Set<T>().Attach(obj);
//         }
//        public void Delete(object id)
//        {
//            T existing = _unitOfWork.Context.Set<T>().Find(id);
//            if (existing != null) _unitOfWork.Context.Set<T>().Remove(existing);

//        }
//        //public void Save()
//        //{
//        //    _context.SaveChanges();
//        //}
//     }
//}