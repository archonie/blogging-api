using Blogging.Domain.Entities;

namespace Blogging.Application.Contracts.Persistence;

public interface IArticleRepository : IGenericRepository<Article>
{
    
}