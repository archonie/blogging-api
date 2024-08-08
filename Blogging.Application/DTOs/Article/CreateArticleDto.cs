namespace Blogging.Application.DTOs.Article;

public class CreateArticleDto 
{
    public string Content { get; set; }
    public string Title { get; set; }
    public int UserId { get; set; }
}