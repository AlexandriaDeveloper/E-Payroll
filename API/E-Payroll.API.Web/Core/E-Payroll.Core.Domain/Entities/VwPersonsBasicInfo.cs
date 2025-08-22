using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class VwPersonsBasicInfo
{
    public long PersonId { get; set; }

    public string PersonType { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? NationalId { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string Status { get; set; } = null!;

    public string? CollegeName { get; set; }

    public string? DepartmentName { get; set; }

    public string? Address { get; set; }

    public string? EmergencyContact { get; set; }

    public string? EmergencyPhone { get; set; }
}
