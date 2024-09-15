using System.Collections.Immutable;
using Crud1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crud1.Data.Mappings;

public class UserMapping: IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.ToTable("User");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(180);

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(180);

        builder.Property(x => x.Salary)
            .HasColumnName("Salary")
            .HasColumnType("DECIMAL");

    }
}