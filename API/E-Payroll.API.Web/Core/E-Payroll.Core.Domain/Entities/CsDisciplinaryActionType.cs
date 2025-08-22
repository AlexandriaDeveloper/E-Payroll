using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class CsDisciplinaryActionType
{
    public long ActionTypeId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int SeverityLevel { get; set; }

    public string Category { get; set; } = null!;

    public string SalaryImpactType { get; set; } = null!;

    public int? MaxDeductionDays { get; set; }

    public decimal? MaxDeductionPercentage { get; set; }

    public decimal? MinDeductionAmount { get; set; }

    public decimal? MaxDeductionAmount { get; set; }

    public bool? AffectsPromotion { get; set; }

    public int? PromotionBanDuration { get; set; }

    public bool? AffectsAllowances { get; set; }

    public int? AllowanceSuspensionDuration { get; set; }

    public bool? AffectsAnnualIncrease { get; set; }

    public bool? RequiresInvestigation { get; set; }

    public bool? RequiresHearing { get; set; }

    public bool? RequiresCouncilDecision { get; set; }

    public bool? CanBeAppealed { get; set; }

    public int? AppealPeriodDays { get; set; }

    public string? ApplicableToGrades { get; set; }

    public int? MaxApplicationsPerYear { get; set; }

    public string LegalBasis { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<CsDisciplinaryAction> CsDisciplinaryActions { get; set; } = new List<CsDisciplinaryAction>();
}
