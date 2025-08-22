using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class FacultySalaryScale
{
    public long ScaleId { get; set; }

    public long RankId { get; set; }

    public int ScaleLevel { get; set; }

    public decimal BasicSalary { get; set; }

    public decimal MinBasicSalary { get; set; }

    public decimal MaxBasicSalary { get; set; }

    public decimal? AcademicAllowance { get; set; }

    public decimal? ResearchAllowance { get; set; }

    public decimal? TeachingAllowance { get; set; }

    public decimal? SupervisionAllowance { get; set; }

    public int? YearsForNextLevel { get; set; }

    public string? PerformanceRequired { get; set; }

    public decimal? IncrementPercentage { get; set; }

    public DateOnly EffectiveFrom { get; set; }

    public DateOnly? EffectiveTo { get; set; }

    public string? DecisionRef { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual FacultyRank Rank { get; set; } = null!;
}
