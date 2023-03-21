using Innogotchi.Application.Interfaces;
using Innogotchi.Domain;
using Microsoft.EntityFrameworkCore;

namespace Innogotchi.Persistence.Repositories;

public class InnoUserRepository : IInnoUserRepository
{
    private readonly InnogotchiDbContext _innogotchiDbContext;

    public InnoUserRepository(InnogotchiDbContext innogotchiDbContext)
    {
        _innogotchiDbContext = innogotchiDbContext;
    }

    public async Task<InnoUser?> GetInnoUserById(Guid id, CancellationToken cancellationToken)
    {
        return await _innogotchiDbContext.InnoUsers.SingleOrDefaultAsync(user => user.InnoUserId == id, cancellationToken);
    }

    public async Task<InnoUser?> GetInnoUserByUsername(string username, CancellationToken cancellationToken)
    {
        return await _innogotchiDbContext.InnoUsers.SingleOrDefaultAsync(user => user.Username == username, cancellationToken);
    }

    public async Task AddInnoUser(InnoUser innoUser, CancellationToken cancellationToken)
    {
        await _innogotchiDbContext.InnoUsers.AddAsync(innoUser, cancellationToken);
        await _innogotchiDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateInnoUser(InnoUser innoUser, CancellationToken cancellationToken)
    {
        var user = await GetInnoUserById(innoUser.InnoUserId, cancellationToken);
        
        if (user is null)
            return;
        
        user.Username = innoUser.Username;
        user.Email = innoUser.Email;
        user.PasswordHash = innoUser.PasswordHash;
        await _innogotchiDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteInnoUser(Guid id, CancellationToken cancellationToken)
    {
        var user = await GetInnoUserById(id, cancellationToken);
        
        if (user is null)
            return;
        
        _innogotchiDbContext.Remove(user);
        await _innogotchiDbContext.SaveChangesAsync(cancellationToken);
    }
}