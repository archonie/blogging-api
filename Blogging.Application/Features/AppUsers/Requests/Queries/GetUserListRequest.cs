using Blogging.Application.DTOs.AppUser;
using MediatR;

namespace Blogging.Application.Features.AppUsers.Requests.Queries;

public class GetUserListRequest : IRequest<List<AppUserDto>>
{
    
}