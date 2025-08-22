using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class Contact
{
    public long ContactId { get; set; }

    public long PersonId { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? EmergencyContact { get; set; }

    public string? EmergencyPhone { get; set; }

    public string? EmergencyRelation { get; set; }

    public string? HomePhone { get; set; }

    public string? WorkExtension { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Person Person { get; set; } = null!;
}
