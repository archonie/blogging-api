using AutoMapper;
using Blogging.Application.Contracts.Persistence;
using Blogging.Application.Features.Articles.Requests.Commands;
using Blogging.Domain.Entities;
using MediatR;

namespace Blogging.Application.Features.Articles.Handlers.Commands;

public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, int>
{
    private readonly IArticleRepository _repository;
    private readonly IMapper _mapper;

    public CreateArticleCommandHandler(IArticleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var article = _mapper.Map<Article>(request.ArticleDto);
        article = await _repository.Add(article);
        return article.Id;
    }
}