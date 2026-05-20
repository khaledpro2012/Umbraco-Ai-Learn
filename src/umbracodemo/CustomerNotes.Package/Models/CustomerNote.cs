namespace CustomerNotes.Package.Models;

public class CustomerNote
{
    public required Guid Id { get; init; }
    public required string CustomerId { get; init; }
    public required string Note { get; set; }
    public required DateTime CreatedAtUtc { get; init; }
}
