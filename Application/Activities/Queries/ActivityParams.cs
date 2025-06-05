using Application.Activities.Core;

namespace Application.Activities.Queries;

public class ActivityParams : PaginatedParams<DateTime?>
{
    public string? Filter { get; set; }

    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    
    
}