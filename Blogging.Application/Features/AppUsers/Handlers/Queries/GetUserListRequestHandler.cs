using AutoMapper;
using Blogging.Application.Contracts.Persistence;
using Blogging.Application.DTOs.AppUser;
using Blogging.Application.Features.AppUsers.Requests.Queries;
using MediatR;

namespace Blogging.Application.Features.AppUsers.Handlers.Queries;

public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, List<AppUserDto>>
{
    private readonly IAppUserRepository _repository;
    private readonly IMapper _mapper;

    public GetUserListRequestHandler(IAppUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<AppUserDto>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
    {
        var users = await _repository.Get();
        return _mapper.Map<List<AppUserDto>>(users);
    }
}