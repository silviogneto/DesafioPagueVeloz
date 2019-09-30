using System.Linq;
using DesafioPagueVeloz.DAL.Models;

namespace DesafioPagueVeloz.DAL.Repositories
{
    public class EmpresaRepository : Repository<Empresa, string>, IEmpresaRepository
    {
        public EmpresaRepository(DatabaseContext context) : base(context)
        {
        }

        public override Empresa GetById(string id) => DbSet.SingleOrDefault(x => x.CNPJ == id);
    }
}
