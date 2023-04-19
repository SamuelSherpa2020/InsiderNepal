using LearnIdentity.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnIdentity.Areas.Identity.Data;

public class LearnIdentityDbContext : IdentityDbContext<LearnIdentityUser>
{
    public LearnIdentityDbContext(DbContextOptions<LearnIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);


        //this is added for firstname and lastname of the field
        builder.ApplyConfiguration(new LearnIdentityEntityConfiguration());
    }
}

public class LearnIdentityEntityConfiguration : IEntityTypeConfiguration<LearnIdentityUser>
{
    public void Configure(EntityTypeBuilder<LearnIdentityUser> builder)
    {
        //throw new NotImplementedException();
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}