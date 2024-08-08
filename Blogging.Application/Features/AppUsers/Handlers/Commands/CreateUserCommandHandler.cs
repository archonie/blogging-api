using Blogging.Application.Contracts.Persistence;
using Blogging.Application.Features.AppUsers.Requests.Commands;
using Blogging.Application.Responses;
using Blogging.Domain.Entities;
using MediatR;

namespace Blogging.Application.Features.AppUsers.Handlers.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RegisterResponse>
{
    private readonly IAppUserRepository _repository;

    public CreateUserCommandHandler(IAppUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<RegisterResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var getUser = await _repository.FindUserByEmail(request.UserDto.Email);
        if (getUser != null)
        {
            return new RegisterResponse(false, "User already registered.");
        }

        var user = new ApplicationUser
        {
            Email = request.UserDto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(request.UserDto.Password),
            Name = request.UserDto.Name,
            Nickname = request.UserDto.Nickname
        };
        await _repository.Add(user);
        return new RegisterResponse(true, "User registered succesfully.");
    }
}