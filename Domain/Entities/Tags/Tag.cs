namespace Domain.Entities.Tags;

public class Tag
{
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;
}