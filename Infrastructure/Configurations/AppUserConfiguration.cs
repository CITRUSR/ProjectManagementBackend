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
                Id = "2B0542C9-472E-4C6D-BD50-02611A0738FE",
                UserName = "CitrusAdmin",
                NormalizedUserName = "CITRUSADMIN",
                PasswordHash = hasher.HashPassword(null, "Qwerty123!"),
                IsConfirmedProfile = true,
            },
            new AppUser
            {
                Id = "AEC05A0F-B6AA-4EE6-AE54-5761C7EF79C9",
                UserName = "CitrusProjectManager",
                NormalizedUserName = "CITRUSPROJECTMANAGER",
                PasswordHash = hasher.HashPassword(null, "Qwerty123!"),
                IsConfirmedProfile = true,
            },
            new AppUser
            {
                Id = "E21345E0-0C23-4043-AFFA-190E960F45DB",
                UserName = "CitrusUser",
                NormalizedUserName = "CITRUSUSER",
                PasswordHash = hasher.HashPassword(null, "Qwerty123!"),
                IsConfirmedProfile = true,
            },
        });
    }
}