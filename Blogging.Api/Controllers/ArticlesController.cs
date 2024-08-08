using Blogging.Application.DTOs.Article;
using Blogging.Application.Features.Articles.Requests.Commands;
using Blogging.Application.Features.Articles.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blogging.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ArticlesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ArticleDto>>> Get()
    {
        var users = await _mediator.Send(new GetArticleListRequest());
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ArticleDto>> Get(int id)
    {
        var users = await _mediator.Send(new GetArticleRequest { Id = id });
        return Ok(users);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateArticleDto articleDto)
    {
        var response = await _mediator.Send(new CreateArticleCommand { ArticleDto = articleDto });
        return Ok(response);
    }

    [HttpPut("{id}/UpdateContent")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateArticleContentDto contentDto)
    {
        contentDto.Id = id;
        await _mediator.Send(new UpdateArticleCommand { ContentDto = contentDto });
        return NoContent();
    }
    [HttpPut("{id}/UpdateTitle")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateArticleTitleDto titleDto)
    {
        titleDto.Id = id;
        await _mediator.Send(new UpdateArticleCommand { TitleDto = titleDto });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteArticleCommand { Id = id });
        return NoContent();
    }
}