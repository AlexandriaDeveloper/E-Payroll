using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class CsSecondment
{
    public long SecondmentId { get; set; }

    public long PersonId { get; set; }

    public long SecondmentTypeId { get; set; }

    public string HostEntity { get; set; } = null!;

    public string? HostEntityType { get; set; }

    public string? Position { get; set; }

    public string? Department { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateOnly? ActualEndDate { get; set; }

    public decimal? WorkingHoursPerDay { get; set; }

    public decimal? SecondmentHoursPerDay { get; set; }

    public decimal? SecondmentPercentage { get; set; }

    public decimal? OriginalSalary { get; set; }

    public decimal? HostEntitySalary { get; set; }

    public decimal? AdditionalAllowance { get; set; }

    public decimal? TransportAllowance { get; set; }

    public string DecisionRef { get; set; } = null!;

    public DateOnly DecisionDate { get; set; }

    public string ApprovalLevel { get; set; } = null!;

    public string? MinisterialApprovalRef { get; set; }

    public string? Status { get; set; }

    public int? RenewalCount { get; set; }

    public string? PerformanceRating { get; set; }

    public string? HostEntityFeedback { get; set; }

    public string? ReturnReason { get; set; }

    public string? Notes { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual CsSecondmentType SecondmentType { get; set; } = null!;
}
