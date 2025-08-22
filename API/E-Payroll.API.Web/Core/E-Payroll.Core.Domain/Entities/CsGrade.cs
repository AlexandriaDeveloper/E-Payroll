using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class CsGrade
{
    public long GradeId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Level { get; set; }

    public string? SubLevel { get; set; }

    public string? FullGradeCode { get; set; }

    public int? MinYearsForPromotion { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<CsPosition> CsPositions { get; set; } = new List<CsPosition>();

    public virtual ICollection<CsPromotion> CsPromotionFromGrades { get; set; } = new List<CsPromotion>();

    public virtual ICollection<CsPromotion> CsPromotionToGrades { get; set; } = new List<CsPromotion>();

    public virtual ICollection<CsSalaryStructure> CsSalaryStructures { get; set; } = new List<CsSalaryStructure>();
}
