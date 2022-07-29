namespace TimeSheet.Domain.Entities;

public record CompanyContract
{
    public int Id { get; set; }
    public int CompanyId { get; init; }
    public int ContractId { get; init; }
    public short DueDay { get; set; }
    public short PaymentDay { get; set; }
    public decimal EarnsPerHour { get; set; }
    public short ClosedHours { get; set; }
    public bool AllowExtraHours { get; set; }
    public DateTime CreatedAt { get; init; }
    public int CreatedByUserId { get; init; }
    public DateTime DeletedAt { get; set; }
    public int DeletedByUserId { get; set; }
}