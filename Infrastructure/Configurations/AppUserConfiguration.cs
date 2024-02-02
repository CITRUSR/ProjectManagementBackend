using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        var hasher = new PasswordHasher<AppUser>();

        builder.HasData(new List<AppUser>
        {
            new AppUser
            {
                Id = "1",
                UserName = "CitrusAdmin",
                NormalizedUserName = "CITRUSADMIN",
                PasswordHash = hasher.HashPassword(null, "Qwerty123!"),
            },
            new AppUser
            {
                Id = "2",
                UserName = "CitrusProjectManager",
                NormalizedUserName = "CITRUSPROJECTMANAGER",
                PasswordHash = hasher.HashPassword(null, "Qwerty123!"),
            },
            new AppUser
            {
                Id = "3",
                UserName = "CitrusUser",
                NormalizedUserName = "CITRUSUSER",
                PasswordHash = hasher.HashPassword(null, "Qwerty123!"),
            },
        });
    }
}