using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.ToTable("Seguridad");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("IdSeguridad");

            builder.Property(e => e.User)
                .IsRequired()
                .HasColumnName("Usuario")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UserName)
                .HasColumnName("NombreUsuario")
                .HasMaxLength(100)
                .IsUnicode(false);

           builder.Property(e => e.Password)
                .HasColumnName("Contrasena")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Role)
                .HasColumnName("Rol")
                .HasMaxLength(15)
                .HasConversion(r => r.ToString(), r => (RoleType)Enum.Parse(typeof(RoleType), r))
                .IsRequired();
        }
    }
}
