using System;
using DesafioPagueVeloz.DAL.Repositories;

namespace DesafioPagueVeloz.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext _context;
        private IEmpresaRepository _empresaRepository;
        private IFornecedorRepository _fornecedorRepository;
        private ITelefoneRepository _telefoneRepository;

        public IEmpresaRepository EmpresaRepository => _empresaRepository ?? (_empresaRepository = new EmpresaRepository(_context));
        public IFornecedorRepository FornecedorRepository => _fornecedorRepository ?? (_fornecedorRepository = new FornecedorRepository(_context));
        public ITelefoneRepository TelefoneRepository => _telefoneRepository ?? (_telefoneRepository = new TelefoneRepository(_context));

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public void ExecInTransaction(Action<IUnitOfWork> callback)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    callback(this);

                    Save();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #region IDisposable

        private bool _disposed = false;

        public void Dispose()
        {
            Clear(true);
            GC.SuppressFinalize(this);
        }

        private void Clear(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

        ~UnitOfWork()
        {
            Clear(false);
        }

        #endregion
    }
}
