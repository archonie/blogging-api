using Blogging.Application.DTOs.Article;
using MediatR;

namespace Blogging.Application.Features.Articles.Requests.Commands;

public class UpdateArticleCommand : IRequest<Unit>
{
    public UpdateArticleContentDto ContentDto { get; set; }
    public UpdateArticleTitleDto TitleDto { get; set; }
}