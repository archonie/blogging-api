using Blogging.Application.DTOs.Article;
using MediatR;

namespace Blogging.Application.Features.Articles.Requests.Commands;

public class CreateArticleCommand : IRequest<int>
{
    public CreateArticleDto ArticleDto { get; set; }
}