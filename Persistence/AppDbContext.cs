using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistence;

public class AppDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public required DbSet<Activity> Activities { get; set; }
    public required DbSet<ActivityAttendee> ActivityAttendees { get; set; }
    public required DbSet<Photo> Photos { get; set; }

    public required DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ActivityAttendee>(x => x.HasKey(e => new { e.ActivityId, e.UserId }));

        builder
            .Entity<ActivityAttendee>()
            .HasOne(a => a.User)
            .WithMany(a => a.Activities)
            .HasForeignKey(a => a.UserId);

        builder
            .Entity<ActivityAttendee>()
            .HasOne(a => a.Activity)
            .WithMany(a => a.Attendees)
            .HasForeignKey(a => a.ActivityId);

        var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
            v => v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
        );

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime))
                {
                    property.SetValueConverter(dateTimeConverter);
                }
            }
        }
    }
}