using MediatR;

namespace Blogging.Application.Features.Articles.Requests.Commands;

public class DeleteArticleCommand : IRequest<Unit>
{
    public int Id { get; set; } 
}