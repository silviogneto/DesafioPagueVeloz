using System;
using DesafioPagueVeloz.DAL.Repositories;

namespace DesafioPagueVeloz.DAL
{
    public interface IUnitOfWork
    {
        IEmpresaRepository EmpresaRepository { get; }
        IFornecedorRepository FornecedorRepository { get; }
        ITelefoneRepository TelefoneRepository { get; }

        void ExecInTransaction(Action<IUnitOfWork> callback);
        void Save();
    }
}
