using Blogging.Application.DTOs.AppUser;
using MediatR;

namespace Blogging.Application.Features.AppUsers.Requests.Queries;

public class GetUserRequest : IRequest<AppUserDto>
{
    public int Id { get; set; }
}