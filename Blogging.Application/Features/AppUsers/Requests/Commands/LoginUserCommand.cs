using Blogging.Application.DTOs.AppUser;
using Blogging.Application.Responses;
using MediatR;

namespace Blogging.Application.Features.AppUsers.Requests.Commands;

public class LoginUserCommand : IRequest<LoginResponse>
{
    public LoginUserDto LoginDto { get; set; }
}