using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class CsSalaryStructure
{
    public long StructureId { get; set; }

    public long GradeId { get; set; }

    public long? PositionId { get; set; }

    public decimal JobWage { get; set; }

    public decimal? TransportAllowanceMin { get; set; }

    public decimal? TransportAllowanceMax { get; set; }

    public decimal? NatureAllowance { get; set; }

    public decimal? VariableAllowance { get; set; }

    public decimal? RepresentationAllowance { get; set; }

    public decimal? SupervisionAllowance { get; set; }

    public DateOnly EffectiveFrom { get; set; }

    public DateOnly? EffectiveTo { get; set; }

    public string? DecisionRef { get; set; }

    public long? ApprovedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual CsGrade Grade { get; set; } = null!;

    public virtual CsPosition? Position { get; set; }
}
