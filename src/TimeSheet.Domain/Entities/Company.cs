using TimeSheet.Domain.Entities.Enums;

namespace TimeSheet.Domain.Entities;

public record Company
{
    public int Id { get; set; }
    public CompanyType CompanyTypeId { get; init; }
    public DateTime CreatedAt { get; init; }
    public int CreatedByUserId { get; init; }
    public DateTime UpdatedAt { get; set; }
    public int UpdatedByUserId { get; set; }
    public DateTime DeletedAt { get; set; }
    public int DeletedByUserId { get; set; }
}