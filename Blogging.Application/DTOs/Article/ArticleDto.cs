using Blogging.Application.DTOs.Common;

namespace Blogging.Application.DTOs.Article;

public record ArticleDto : BaseDto
{
    public string Content { get; set; }
    public string Title { get; set; }
    public int UserId { get; set; }
}