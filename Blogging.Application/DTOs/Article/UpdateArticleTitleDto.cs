using Blogging.Application.DTOs.Common;

namespace Blogging.Application.DTOs.Article;

public record UpdateArticleTitleDto : BaseDto
{
    public string Title { get; set; }
}