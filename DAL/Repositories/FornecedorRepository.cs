using System.Linq;
using DesafioPagueVeloz.DAL.Models;

namespace DesafioPagueVeloz.DAL.Repositories
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(DatabaseContext context) : base(context)
        {
        }

        public override Fornecedor GetById(int id) => DbSet.SingleOrDefault(x => x.Id == id);
    }
}
