using System.Collections.Generic;
using System.Linq;

namespace VegaBusinessLayer
{
    public abstract class BaseRepository<TPoco> where TPoco : class
    {

        protected IGenericRepository<TPoco> _repository;

        public BaseRepository(IGenericRepository<TPoco> repository)
        {
            _repository = repository;
        }
        protected virtual void Verify(TPoco pocos)
        {
            return;
        }
        public virtual TPoco Get(int Id)
        {
            return _repository.GetById(Id);
        }
        public virtual List<TPoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public virtual void Add(TPoco pocos)
        {
            _repository.Insert(pocos);
            _repository.Save();
        }

        public virtual void Update(TPoco pocos)
        {
            _repository.Update(pocos);
            _repository.Save();
        }
        public virtual void Delete(int  Id)
        {
            _repository.Delete(Id);
            _repository.Save();
        }
    }
}
