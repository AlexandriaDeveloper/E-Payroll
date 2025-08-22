using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class RequestApproval
{
    public long ApprovalId { get; set; }

    public long RequestId { get; set; }

    public string ApprovalStage { get; set; } = null!;

    public int ApprovalOrder { get; set; }

    public long ApproverId { get; set; }

    public string? ApproverTitle { get; set; }

    public string? ApproverRole { get; set; }

    public string Decision { get; set; } = null!;

    public DateTime DecisionDate { get; set; }

    public string? DecisionNotes { get; set; }

    public decimal? AmountAdjustment { get; set; }

    public int? DurationAdjustment { get; set; }

    public string? DateAdjustment { get; set; }

    public bool? IsDelegate { get; set; }

    public long? DelegateFor { get; set; }

    public int? ProcessingTime { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Person Approver { get; set; } = null!;

    public virtual Request Request { get; set; } = null!;
}
