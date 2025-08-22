using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class FacultyLeaveApplication
{
    public long ApplicationId { get; set; }

    public long PersonId { get; set; }

    public long LeaveTypeId { get; set; }

    public long? RequestId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int? TotalDays { get; set; }

    public DateOnly? ActualStartDate { get; set; }

    public DateOnly? ActualEndDate { get; set; }

    public int? ActualDays { get; set; }

    public bool? AllowancesAffected { get; set; }

    public bool? DeductionCalculated { get; set; }

    public decimal? TotalDeductionAmount { get; set; }

    public string? ApprovalStatus { get; set; }

    public long? ApprovedBy { get; set; }

    public DateOnly? ApprovalDate { get; set; }

    public string? ImplementationStatus { get; set; }

    public long? ImplementedBy { get; set; }

    public DateOnly? ImplementationDate { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public virtual ICollection<FacultyAllowanceDeduction> FacultyAllowanceDeductions { get; set; } = new List<FacultyAllowanceDeduction>();

    public virtual FacultyLeaveType LeaveType { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual Request? Request { get; set; }
}
