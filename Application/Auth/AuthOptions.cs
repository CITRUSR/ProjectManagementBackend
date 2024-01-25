using Microsoft.Extensions.Configuration;

namespace Application.Auth;

public class AuthOptions
{
    public string Issuer { get; }
    public string Audience { get; }
    public string Secret { get; }
    public int LifeTimeInDays { get;}
    
    private readonly IConfiguration _configuration;
    
    public AuthOptions(IConfiguration configuration)
    {
        _configuration = configuration;
        Issuer = _configuration.GetValue<string>("AuthParameters:Issuer");
        Audience = _configuration.GetValue<string>("AuthParameters:Audience");
        Secret = _configuration.GetValue<string>("AuthParameters:Secret");
        LifeTimeInDays = _configuration.GetValue<int>("AuthParameters:LifeTimeInDays");
    }
}