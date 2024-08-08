using Blogging.Application.Contracts.Persistence;
using Blogging.Application.Exceptions;
using Blogging.Application.Features.Articles.Requests.Commands;
using Blogging.Domain.Entities;
using MediatR;

namespace Blogging.Application.Features.Articles.Handlers.Commands;

public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, Unit>
{
    private readonly IArticleRepository _repository;

    public DeleteArticleCommandHandler(IArticleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        var article = await _repository.Get(request.Id);
        if (article == null)
        {
            throw new NotFoundException(nameof(Article), request.Id);
        }

        await _repository.Delete(article);
        return Unit.Value;
    }
}