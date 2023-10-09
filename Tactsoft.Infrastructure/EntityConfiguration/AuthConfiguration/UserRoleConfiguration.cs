﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Tactsoft.Domain.Identities.IdentityModel;

namespace Tactsoft.Infrastructure.EntityConfiguration.AuthConfiguration;
public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasData(new UserRole
        {
            RoleId = 1,
            UserId = 1,
        }, new UserRole
        {
            RoleId = 2,
            UserId = 2,
        }, new UserRole
        {
            RoleId = 3,
            UserId = 3,
        }, new UserRole
        {
            RoleId = 4,
            UserId = 4,
        });
    }
}
