using Blogging.Application.DTOs.Common;

namespace Blogging.Application.DTOs.Article;

public record UpdateArticleContentDto : BaseDto
{
    public string Content { get; set; }
 
}