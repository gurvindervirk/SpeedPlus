using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaModel;

namespace VegaBusinessLayer.NonGenricRepositories
{
    public interface IUnitOfWork : IDisposable
    {
       IDatabaseTransaction BeginTransaction();

        
    }
}
