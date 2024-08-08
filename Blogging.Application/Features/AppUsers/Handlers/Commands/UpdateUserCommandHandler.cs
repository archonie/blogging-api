using AutoMapper;
using Blogging.Application.Contracts.Persistence;
using Blogging.Application.Features.AppUsers.Requests.Commands;
using MediatR;

namespace Blogging.Application.Features.AppUsers.Handlers.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IAppUserRepository _repository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IAppUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.Get(request.UpdateUserDto.Id);
        _mapper.Map(request.UpdateUserDto, user);
        return Unit.Value;
    }
}