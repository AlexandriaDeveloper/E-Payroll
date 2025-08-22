using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class CsDisciplinaryAction
{
    public long ActionId { get; set; }

    public long PersonId { get; set; }

    public long ActionTypeId { get; set; }

    public string CaseNumber { get; set; } = null!;

    public DateOnly IncidentDate { get; set; }

    public DateOnly ActionDate { get; set; }

    public string ViolationDescription { get; set; } = null!;

    public string Reason { get; set; } = null!;

    public string? Evidence { get; set; }

    public decimal? DeductionAmount { get; set; }

    public int? DeductionDays { get; set; }

    public DateOnly? DeductionStartDate { get; set; }

    public DateOnly? DeductionEndDate { get; set; }

    public DateOnly? SuspensionStartDate { get; set; }

    public DateOnly? SuspensionEndDate { get; set; }

    public bool? SuspensionWithoutPay { get; set; }

    public bool? AllowancesSuspended { get; set; }

    public DateOnly? AllowanceSuspensionUntil { get; set; }

    public bool? PromotionBan { get; set; }

    public DateOnly? PromotionBanUntil { get; set; }

    public string? InvestigationRef { get; set; }

    public DateOnly? HearingDate { get; set; }

    public string? DefenseStatement { get; set; }

    public string DecisionRef { get; set; } = null!;

    public string DecisionMaker { get; set; } = null!;

    public string? Status { get; set; }

    public DateOnly? ImplementationDate { get; set; }

    public DateOnly? CompletionDate { get; set; }

    public bool? AppealSubmitted { get; set; }

    public DateOnly? AppealDate { get; set; }

    public string? AppealDecision { get; set; }

    public string? AppealResult { get; set; }

    public bool? IsReversed { get; set; }

    public string? ReversalReason { get; set; }

    public DateOnly? ReversalDate { get; set; }

    public string? Notes { get; set; }

    public long CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual CsDisciplinaryActionType ActionType { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
