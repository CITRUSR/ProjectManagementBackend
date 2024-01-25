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
                UserId = "1",
            },
            new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = "2",
            },
            new IdentityUserRole<string>
            {
                RoleId = "3",
                UserId = "3",
            }
        });
    }
}