using Innogotchi.Domain;

namespace Innogotchi.Application.Interfaces;

public interface IInnoUserRepository
{
    public Task<InnoUser?> GetInnoUserById(Guid id, CancellationToken cancellationToken);
    public Task<InnoUser?> GetInnoUserByUsername(string username, CancellationToken cancellationToken);
    public Task AddInnoUser(InnoUser innoUser, CancellationToken cancellationToken);
    public Task UpdateInnoUser(InnoUser innoUser, CancellationToken cancellationToken);
    public Task DeleteInnoUser(Guid id, CancellationToken cancellationToken);
}