using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class Request
{
    public long RequestId { get; set; }

    public long PersonId { get; set; }

    public string RequestType { get; set; } = null!;

    public string? RequestNumber { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? Priority { get; set; }

    public DateOnly? RequestedStartDate { get; set; }

    public DateOnly? RequestedEndDate { get; set; }

    public int? ExpectedDuration { get; set; }

    public decimal? RequestedAmount { get; set; }

    public decimal? ApprovedAmount { get; set; }

    public string? CurrentStage { get; set; }

    public long? CurrentApprover { get; set; }

    public long? NextApprover { get; set; }

    public DateTime? SubmittedAt { get; set; }

    public DateOnly? RequiredByDate { get; set; }

    public DateTime? FinalApprovalDate { get; set; }

    public DateOnly? ImplementationDate { get; set; }

    public DateOnly? CompletionDate { get; set; }

    public string? Status { get; set; }

    public string? FinalDecision { get; set; }

    public string? RejectionReason { get; set; }

    public int? AttachmentsCount { get; set; }

    public string? RequiredDocuments { get; set; }

    public string? LegalBasis { get; set; }

    public string? DecisionRef { get; set; }

    public string? Notes { get; set; }

    public long? SubmittedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public virtual ICollection<FacultyLeaveApplication> FacultyLeaveApplications { get; set; } = new List<FacultyLeaveApplication>();

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<RequestApproval> RequestApprovals { get; set; } = new List<RequestApproval>();
}
