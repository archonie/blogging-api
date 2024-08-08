using Blogging.Application.DTOs.AppUser;
using MediatR;

namespace Blogging.Application.Features.AppUsers.Requests.Commands;

public class UpdateUserCommand : IRequest<Unit>
{
    public UpdateUserDto UpdateUserDto { get; set; }
}