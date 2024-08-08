using Blogging.Application.Contracts.Persistence;
using Blogging.Domain.Entities;

namespace Blogging.Persistence.Repositories;

public class ArticleRepository : GenericRepository<Article>, IArticleRepository
{
    public ArticleRepository(BlogDbContext dbContext) : base(dbContext)
    {
    }
}