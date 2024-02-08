using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "2B0542C9-472E-4C6D-BD50-02611A0738FE",
            },
            new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = "AEC05A0F-B6AA-4EE6-AE54-5761C7EF79C9",
            },
            new IdentityUserRole<string>
            {
                RoleId = "3",
                UserId = "E21345E0-0C23-4043-AFFA-190E960F45DB",
            }
        });
    }
}