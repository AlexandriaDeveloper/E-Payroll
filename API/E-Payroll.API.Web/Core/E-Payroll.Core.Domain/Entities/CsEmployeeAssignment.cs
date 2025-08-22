using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class CsEmployeeAssignment
{
    public long AssignmentId { get; set; }

    public long PersonId { get; set; }

    public long PositionId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? AssignmentType { get; set; }

    public string? DecisionRef { get; set; }

    public DateOnly? DecisionDate { get; set; }

    public string? LegalBasis { get; set; }

    public int? ProbationPeriod { get; set; }

    public DateOnly? ProbationEndDate { get; set; }

    public decimal? CurrentSalary { get; set; }

    public string? Notes { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual CsPosition Position { get; set; } = null!;
}
