using InnoFridges.Application.Interfaces;
using InnoFridges.Domain;
using saja;
using saja.Interfaces;

namespace InnoFridges.Persistence.Repositories;

public class InnoUserRepository : UserModelBaseRepository<InnoUser, InnogotchiDbContext>, IInnoUserRepository
{
    public InnoUserRepository(InnogotchiDbContext dbContext) : base(dbContext)
    {
    }
}