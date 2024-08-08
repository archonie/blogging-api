using AutoMapper;
using Blogging.Application.DTOs.AppUser;
using Blogging.Application.DTOs.Article;
using Blogging.Domain.Entities;

namespace Blogging.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ApplicationUser, AppUserDto>().ReverseMap();
        CreateMap<ApplicationUser, CreateUserDto>().ReverseMap();
        CreateMap<ApplicationUser, UpdateUserDto>().ReverseMap();
        CreateMap<Article, ArticleDto>().ReverseMap();
        CreateMap<Article, CreateArticleDto>().ReverseMap();
        CreateMap<Article, UpdateArticleContentDto>().ReverseMap();
        CreateMap<Article, UpdateArticleTitleDto>().ReverseMap();
    }
}