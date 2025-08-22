using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class FacultyCurrentSalaryLevel
{
    public long LevelId { get; set; }

    public long PersonId { get; set; }

    public long RankId { get; set; }

    public int CurrentScaleLevel { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? NextLevelEligibleDate { get; set; }

    public string? LastPerformanceRating { get; set; }

    public DateOnly? LastEvaluationDate { get; set; }

    public bool? CanProgress { get; set; }

    public bool? ReachedMaximum { get; set; }

    public int? YearsInCurrentLevel { get; set; }

    public int? TotalYearsInRank { get; set; }

    public decimal? LastIncrementAmount { get; set; }

    public decimal? NextIncrementAmount { get; set; }

    public string? Notes { get; set; }

    public DateTime? LastUpdated { get; set; }

    public long? UpdatedBy { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual FacultyRank Rank { get; set; } = null!;
}
