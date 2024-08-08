using Blogging.Application.Contracts.Persistence;
using Blogging.Application.Exceptions;
using Blogging.Application.Features.AppUsers.Requests.Commands;
using Blogging.Application.Responses;
using Blogging.Domain.Entities;
using MediatR;

namespace Blogging.Application.Features.AppUsers.Handlers.Commands;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponse>
{
    private readonly IAppUserRepository _repository;

    public LoginUserCommandHandler(IAppUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<LoginResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var getUser = await _repository.FindUserByEmail(request.LoginDto.Email);
        if (getUser == null)
        {
            throw new NotFoundException(nameof(ApplicationUser), request.LoginDto.Email);
        }
        var checkPassword = BCrypt.Net.BCrypt.Verify(request.LoginDto.Password, getUser.Password);
        if (!checkPassword)
        {
            return new LoginResponse(false, "Password is not correct.");
        }

        return new LoginResponse(true, "Login successful.", _repository.GenerateToken(getUser));
    }
}