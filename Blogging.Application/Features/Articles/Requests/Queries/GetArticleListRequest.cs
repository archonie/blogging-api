using Blogging.Application.DTOs.Article;
using MediatR;

namespace Blogging.Application.Features.Articles.Requests.Queries;

public class GetArticleListRequest : IRequest<List<ArticleDto>>
{
    
}