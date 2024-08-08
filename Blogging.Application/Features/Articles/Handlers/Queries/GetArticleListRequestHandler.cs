using AutoMapper;
using Blogging.Application.Contracts.Persistence;
using Blogging.Application.DTOs.Article;
using Blogging.Application.Features.Articles.Requests.Queries;
using Blogging.Domain.Entities;
using MediatR;

namespace Blogging.Application.Features.Articles.Handlers.Queries;

public class GetArticleListRequestHandler : IRequestHandler<GetArticleListRequest, List<ArticleDto>>
{
    private readonly IArticleRepository _repository;
    private readonly IMapper _mapper;

    public GetArticleListRequestHandler(IArticleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<ArticleDto>> Handle(GetArticleListRequest request, CancellationToken cancellationToken)
    {
        var articles = await _repository.Get();
        return _mapper.Map<List<ArticleDto>>(articles);
    }
}