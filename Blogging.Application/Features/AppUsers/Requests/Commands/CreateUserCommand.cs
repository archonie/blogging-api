using Blogging.Application.DTOs.AppUser;
using Blogging.Application.Responses;
using MediatR;

namespace Blogging.Application.Features.AppUsers.Requests.Commands;

public class CreateUserCommand : IRequest<RegisterResponse>
{
    public CreateUserDto UserDto { get; set; }
}