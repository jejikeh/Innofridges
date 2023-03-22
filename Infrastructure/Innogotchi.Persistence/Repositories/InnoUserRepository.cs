using Innogotchi.Application.Interfaces;
using Innogotchi.Domain;
using saja;
using saja.Interfaces;

namespace Innogotchi.Persistence.Repositories;

public class InnoUserRepository : UserModelBaseRepository<InnoUser, InnogotchiDbContext>, IInnoUserRepository
{
    public InnoUserRepository(InnogotchiDbContext dbContext) : base(dbContext)
    {
    }
}