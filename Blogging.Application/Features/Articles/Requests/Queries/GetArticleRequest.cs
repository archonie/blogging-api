using Blogging.Application.DTOs.Article;
using MediatR;

namespace Blogging.Application.Features.Articles.Requests.Queries;

public class GetArticleRequest : IRequest<ArticleDto>
{
    public int Id { get; set; }
}