using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class CsPosition
{
    public long PositionId { get; set; }

    public string Code { get; set; } = null!;

    public string Title { get; set; } = null!;

    public long GradeId { get; set; }

    public long DepartmentId { get; set; }

    public string? JobDescription { get; set; }

    public string? RequiredQualifications { get; set; }

    public int? RequiredExperience { get; set; }

    public bool? IsSupervision { get; set; }

    public int? MaxPositions { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<CsEmployeeAssignment> CsEmployeeAssignments { get; set; } = new List<CsEmployeeAssignment>();

    public virtual ICollection<CsSalaryStructure> CsSalaryStructures { get; set; } = new List<CsSalaryStructure>();

    public virtual Department Department { get; set; } = null!;

    public virtual CsGrade Grade { get; set; } = null!;
}
