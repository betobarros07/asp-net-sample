using TimeSheet.Domain.Entities.Enums;

namespace TimeSheet.Domain.Entities;

public record User
{
    public int Id { get; set; }
    public int PersonId { get; init; }
    public int CompanyId { get; init; }
    public string Username { get; init; } = default!;
    public string Password { get; set; } = default!;
    public DateTime CreatedAt { get; init; }
    public int CreatedByUserId { get; init; }
    public DateTime UpdatedAt { get; set; }
    public int UpdatedByUserId { get; set; }
    public DateTime DeletedAt { get; set; }
    public int DeletedByUserId { get; set; }
}