using System.Globalization;
using AutoMapper;
using Blogging.Application.Contracts.Persistence;
using Blogging.Application.Exceptions;
using Blogging.Application.Features.Articles.Requests.Commands;
using Blogging.Domain.Entities;
using MediatR;

namespace Blogging.Application.Features.Articles.Handlers.Commands;

public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, Unit>
{
    private readonly IArticleRepository _repository;
    private readonly IMapper _mapper;

    public UpdateArticleCommandHandler(IArticleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        if (request.TitleDto != null)
        {
            var article = await _repository.Get(request.TitleDto.Id);
            if (article == null)
            {
                throw new NotFoundException(nameof(Article), request.TitleDto.Id);
            }

            article = _mapper.Map(request.TitleDto, article);
            await _repository.Update(article);
        }

        if (request.ContentDto != null)
        {
            var article = await _repository.Get(request.ContentDto.Id);
            if (article == null)
            {
                throw new NotFoundException(nameof(Article), request.ContentDto.Id);
            }

            article = _mapper.Map(request.ContentDto, article);
            await _repository.Update(article);
        }

        return Unit.Value;
    }
}