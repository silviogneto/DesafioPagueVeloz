using System.Linq;
using DesafioPagueVeloz.DAL.Models;

namespace DesafioPagueVeloz.DAL.Repositories
{
    public class TelefoneRepository : Repository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(DatabaseContext context) : base(context)
        {
        }

        public override Telefone GetById(int id) => DbSet.SingleOrDefault(x => x.Id == id);
    }
}
