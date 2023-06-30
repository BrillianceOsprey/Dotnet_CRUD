using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_CRUD.Domain.DBContexts;

namespace Dotnet_CRUD.Domain.Repository.Interfaces
{
    public interface IDBUnitOfWork : IDisposable
    {
        dotnet_DBContext DBContext { get; } // to call database
        void Commit();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}