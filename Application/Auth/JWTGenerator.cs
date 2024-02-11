using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Auth;

public class JWTGenerator(AuthOptions authOptions, UserManager<AppUser> userManager)
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly AuthOptions _authOptions = authOptions;

    public async Task<string> Generate(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
        };

        foreach (var role in await _userManager.GetRolesAsync(user))
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var jwt = new JwtSecurityToken(issuer: _authOptions.Issuer,
            audience: _authOptions.Audience,
            expires: DateTime.Now.AddDays(_authOptions.LifeTimeInDays),
            claims: claims,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.Secret)), SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}