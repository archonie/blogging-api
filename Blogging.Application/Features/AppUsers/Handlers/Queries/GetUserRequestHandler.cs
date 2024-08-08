using AutoMapper;
using Blogging.Application.Contracts.Persistence;
using Blogging.Application.DTOs.AppUser;
using Blogging.Application.Features.AppUsers.Requests.Queries;
using Blogging.Domain.Entities;
using MediatR;

namespace Blogging.Application.Features.AppUsers.Handlers.Queries;

public class GetUserRequestHandler : IRequestHandler<GetUserRequest, AppUserDto>
{
    private readonly IAppUserRepository _repository;
    private readonly IMapper _mapper;

    public GetUserRequestHandler(IAppUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AppUserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        return _mapper.Map<AppUserDto>(await _repository.Get(request.Id));
    }
}