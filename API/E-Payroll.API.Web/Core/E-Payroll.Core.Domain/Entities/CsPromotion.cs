using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class CsPromotion
{
    public long PromotionId { get; set; }

    public long PersonId { get; set; }

    public long FromGradeId { get; set; }

    public long ToGradeId { get; set; }

    public string PromotionType { get; set; } = null!;

    public DateOnly EffectiveDate { get; set; }

    public string DecisionRef { get; set; } = null!;

    public DateOnly DecisionDate { get; set; }

    public decimal? OldSalary { get; set; }

    public decimal? NewSalary { get; set; }

    public decimal? SalaryIncrease { get; set; }

    public string? PerformanceRating { get; set; }

    public int? YearsInGrade { get; set; }

    public string? CommitteeMinutes { get; set; }

    public string? CouncilDecisionRef { get; set; }

    public DateOnly? BackdatedFrom { get; set; }

    public decimal? BackpayAmount { get; set; }

    public bool? IsReversed { get; set; }

    public string? ReversalReason { get; set; }

    public string? Notes { get; set; }

    public long? ApprovedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual CsGrade FromGrade { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual CsGrade ToGrade { get; set; } = null!;
}
