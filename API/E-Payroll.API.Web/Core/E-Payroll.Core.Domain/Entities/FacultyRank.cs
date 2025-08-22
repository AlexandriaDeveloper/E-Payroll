using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class FacultyRank
{
    public long RankId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? NameEn { get; set; }

    public int SortOrder { get; set; }

    public int? MinYearsForPromotion { get; set; }

    public string? RequiredDegree { get; set; }

    public string? RequiredExperience { get; set; }

    public int? TeachingLoad { get; set; }

    public string? ResearchRequirement { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<FacultyAppointment> FacultyAppointments { get; set; } = new List<FacultyAppointment>();

    public virtual ICollection<FacultyCurrentSalaryLevel> FacultyCurrentSalaryLevels { get; set; } = new List<FacultyCurrentSalaryLevel>();

    public virtual ICollection<FacultySalaryScale> FacultySalaryScales { get; set; } = new List<FacultySalaryScale>();
}
