using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = "1"
            },
            new IdentityRole
            {
                Name = "ProjectManager",
                NormalizedName = "PROJECTMANAGER",
                Id = "2"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "3"
            }
        });
    }
}