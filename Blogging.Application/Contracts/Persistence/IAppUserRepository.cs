using Blogging.Domain.Entities;

namespace Blogging.Application.Contracts.Persistence;

public interface IAppUserRepository : IGenericRepository<ApplicationUser>
{
    Task<ApplicationUser> FindUserByEmail(string email);
    string GenerateToken(ApplicationUser user);
    Task<ApplicationUser> GetUserWithArticles(int id);
}