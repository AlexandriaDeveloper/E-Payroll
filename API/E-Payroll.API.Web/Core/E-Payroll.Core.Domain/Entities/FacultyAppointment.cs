using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class FacultyAppointment
{
    public long AppointmentId { get; set; }

    public long PersonId { get; set; }

    public long RankId { get; set; }

    public long DepartmentId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? AppointmentType { get; set; }

    public string DecisionRef { get; set; } = null!;

    public DateOnly DecisionDate { get; set; }

    public string? CouncilMinutes { get; set; }

    public int? StartingSalaryLevel { get; set; }

    public string? LegalBasis { get; set; }

    public int? ProbationPeriod { get; set; }

    public DateOnly? ProbationEndDate { get; set; }

    public string? Notes { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual FacultyRank Rank { get; set; } = null!;
}
