using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext;
using VegaBusinessLayer.NonGenricRepositories;
using VegaModel;

namespace VegaBusinessLayer.GenericRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VegaContext _context;
        public GenericRepository<CountryModel> CountryModelRepository;
        public GenericRepository<AreaModel> AreaModelRepository;
        public GenericRepository<AccountModel> AccountModelRepository;
        public GenericRepository<TransactionModel> TransactionModelRepository;
        public GenericRepository<LedgerModel> LedgerModelRepository;
        public GenericRepository<SecurityLoginsRoleModel> SecurityLoginsRoleModelRepository;
        public GenericRepository<SecurityLoginModel> SecurityLoginModelRepository;
       
        public UnitOfWork(VegaContext context)
        {
            _context = context;
            this.CountryModelRepository = new GenericRepository<CountryModel>(_context);
            this.AreaModelRepository = new GenericRepository<AreaModel>(_context);
            this.AccountModelRepository = new GenericRepository<AccountModel>(_context);
            this.TransactionModelRepository = new GenericRepository<TransactionModel>(_context);
            this.LedgerModelRepository = new GenericRepository<LedgerModel>(_context);
            this.SecurityLoginsRoleModelRepository = new GenericRepository<SecurityLoginsRoleModel>(_context);
            this.SecurityLoginModelRepository = new GenericRepository<SecurityLoginModel>(_context);
        }

        public UnitOfWork() : this(new VegaContext())
        {
        }

        public void Save()
        {
            _context.SaveChanges();
        }
      public void Dispose()
        {
            _context.Dispose();
        }
        public IDatabaseTransaction BeginTransaction()
        {
             return new EntityDatabaseTransaction(_context);
        }
    }
}
