using Bookify.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Infrastructure.Configurations;

public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles");

        builder.HasKey(r => r.Id);

        builder.HasMany(r => r.Users)
            .WithMany(u => u.Roles);

        // Cấu hình mối quan hệ many-to-many với Permission
        builder.HasMany(r => r.Permissions)
            .WithMany()
            .UsingEntity<RolePermission>(
                "role_permissions",
                l => l.HasOne<Permission>().WithMany().HasForeignKey(rp => rp.PermissionId),
                r => r.HasOne<Role>().WithMany().HasForeignKey(rp => rp.RoleId),
                je =>
                {
                    je.HasKey(rp => new { rp.RoleId, rp.PermissionId });
                    je.HasData(new RolePermission
                    {
                        RoleId = Role.Registered.Id,
                        PermissionId = Permission.UsersRead.Id
                    });
                });

        builder.HasData(Role.Registered);
    }
}