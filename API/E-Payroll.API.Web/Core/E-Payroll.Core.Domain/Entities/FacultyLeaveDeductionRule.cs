using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class FacultyLeaveDeductionRule
{
    public long RuleId { get; set; }

    public long LeaveTypeId { get; set; }

    public long PayElementId { get; set; }

    public string DeductionType { get; set; } = null!;

    public decimal? DeductionPercentage { get; set; }

    public int? GraceDays { get; set; }

    public int? FullDeductionAfterDays { get; set; }

    public bool? AppliesOnlyToExcessDays { get; set; }

    public string? ExemptionConditions { get; set; }

    public string? Formula { get; set; }

    public string? Notes { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly? EffectiveFrom { get; set; }

    public DateOnly? EffectiveTo { get; set; }

    public virtual ICollection<FacultyAllowanceDeduction> FacultyAllowanceDeductions { get; set; } = new List<FacultyAllowanceDeduction>();

    public virtual FacultyLeaveType LeaveType { get; set; } = null!;

    public virtual PayElement PayElement { get; set; } = null!;
}
