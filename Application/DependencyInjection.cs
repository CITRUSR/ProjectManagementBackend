using System.Reflection;
using Application.Auth;
using Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        
        services.AddSingleton<AuthOptions>();
        services.AddScoped<JWTGenerator>();
        
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly));
        
        services.AddValidatorsFromAssembly(assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        return services;
    }
}