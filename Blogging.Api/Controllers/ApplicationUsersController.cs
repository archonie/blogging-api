using Blogging.Application.DTOs.AppUser;
using Blogging.Application.Features.AppUsers.Requests.Commands;
using Blogging.Application.Features.AppUsers.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blogging.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationUsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public ApplicationUsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<AppUserDto>>> Get()
    {
        var users = await _mediator.Send(new GetUserListRequest());
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUserDto>> Get(int id)
    {
        var user = await _mediator.Send(new GetUserRequest{ Id = id });
        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<ActionResult> Post([FromBody] CreateUserDto user)
    {
        var command = new CreateUserCommand { UserDto = user };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    
    [HttpPost("login")]
    public async Task<ActionResult> Post([FromBody] LoginUserDto user)
    {
        var command = new LoginUserCommand { LoginDto = user };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateUserDto user)
    {
        user.Id = id;
        var command = new UpdateUserCommand { UpdateUserDto = user };
        await _mediator.Send(command);
        return NoContent();
    }
    

    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteUserCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}