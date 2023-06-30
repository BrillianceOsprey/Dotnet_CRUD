using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_CRUD.Domain.DBContexts;
using Dotnet_CRUD.Domain.Repository.Interfaces;

namespace Dotnet_CRUD.Domain.Repository
{
    public class DBUnitofwork : IDBUnitOfWork
    {
        public bool disposed = false;
        public readonly dotnet_DBContext _context;
        public DBUnitofwork(dotnet_DBContext context)
        {
            _context = context;
        }

        public dotnet_DBContext DBContext
        {
            get
            {
                return _context;
            }
        }

        #region [Begin, Commit and Rollback Transaction]

        public void Commit()
        {
            try
            {
                _context.SaveChanges();

            }
            catch (ValidationException vexp)
            {
                foreach (var exp in vexp.Data.Values)
                {
                    string error = exp.ToString();
                    Console.WriteLine(error);
                }
            }
        }


        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        #endregion



    }
}


