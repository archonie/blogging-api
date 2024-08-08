using AutoMapper;
using Blogging.Application.Contracts.Persistence;
using Blogging.Application.DTOs.Article;
using Blogging.Application.Features.Articles.Requests.Queries;
using MediatR;

namespace Blogging.Application.Features.Articles.Handlers.Queries;

public class GetArticleRequestHandler : IRequestHandler<GetArticleRequest, ArticleDto>
{
    private readonly IArticleRepository _repository;
    private readonly IMapper _mapper;

    public GetArticleRequestHandler(IArticleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ArticleDto> Handle(GetArticleRequest request, CancellationToken cancellationToken)
    {
        var article = await _repository.Get(request.Id);
        return _mapper.Map<ArticleDto>(article);
    }
}