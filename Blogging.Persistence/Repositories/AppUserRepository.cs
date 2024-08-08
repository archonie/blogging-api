using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blogging.Application.Contracts.Persistence;
using Blogging.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Blogging.Persistence.Repositories;

public class AppUserRepository : GenericRepository<ApplicationUser>, IAppUserRepository
{
    private readonly BlogDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public AppUserRepository(BlogDbContext dbContext, IConfiguration configuration) : base(dbContext)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public async Task<ApplicationUser> FindUserByEmail(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public string GenerateToken(ApplicationUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var userClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: userClaims,
            expires: DateTime.Now.AddDays(5),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<ApplicationUser> GetUserWithArticles(int id)
    {
        return await _dbContext.Users
            .Include(u => u.Articles)
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}