using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class Department
{
    public long DepartmentId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public long? ParentDepartmentId { get; set; }

    public long CollegeId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual College College { get; set; } = null!;

    public virtual ICollection<CsPosition> CsPositions { get; set; } = new List<CsPosition>();

    public virtual ICollection<FacultyAppointment> FacultyAppointments { get; set; } = new List<FacultyAppointment>();

    public virtual ICollection<Department> InverseParentDepartment { get; set; } = new List<Department>();

    public virtual Department? ParentDepartment { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
