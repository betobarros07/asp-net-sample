using TimeSheet.Domain.Entities.Enums;

namespace TimeSheet.Domain.Entities;

public record CompanyContractPayment
{
    public int Id { get; set; }
    public int CompanyContractId { get; init; }
    public CompanyContractPaymentStatus CompanyContractPaymentStatusId { get; set; }
    public short DueDay { get; init; }
    public short PaymentDay { get; init; }
    public decimal EarnsPerHour { get; init; }
    public short ClosedHours { get; init; }
    public bool AllowExtraHours { get; init; }
    public decimal MonthSalary { get; set; }
    public decimal PreviewSalary { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int UpdatedByUserId { get; set; }
}