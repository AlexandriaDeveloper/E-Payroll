using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class FacultyAllowanceDeduction
{
    public long DeductionId { get; set; }

    public long ApplicationId { get; set; }

    public long PersonId { get; set; }

    public long PayElementId { get; set; }

    public DateOnly DeductionStartDate { get; set; }

    public DateOnly DeductionEndDate { get; set; }

    public decimal OriginalAmount { get; set; }

    public decimal DeductionPercentage { get; set; }

    public decimal DeductionAmount { get; set; }

    public int? DeductionDays { get; set; }

    public decimal? NetAmount { get; set; }

    public long? RuleId { get; set; }

    public string DeductionType { get; set; } = null!;

    public int? GraceDaysApplied { get; set; }

    public string? CalculationMethod { get; set; }

    public string? Formula { get; set; }

    public string? Notes { get; set; }

    public DateTime? CalculatedAt { get; set; }

    public long? CalculatedBy { get; set; }

    public virtual FacultyLeaveApplication Application { get; set; } = null!;

    public virtual PayElement PayElement { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual FacultyLeaveDeductionRule? Rule { get; set; }
}
