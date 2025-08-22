using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class Person
{
    public long PersonId { get; set; }

    public string? NationalId { get; set; }

    public string PersonType { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly? BirthDate { get; set; }

    public DateOnly? HireDate { get; set; }

    public string Status { get; set; } = null!;

    public long? DepartmentId { get; set; }

    public long? CollegeId { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual College? College { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<CsDisciplinaryAction> CsDisciplinaryActions { get; set; } = new List<CsDisciplinaryAction>();

    public virtual ICollection<CsEmployeeAssignment> CsEmployeeAssignments { get; set; } = new List<CsEmployeeAssignment>();

    public virtual ICollection<CsPromotion> CsPromotions { get; set; } = new List<CsPromotion>();

    public virtual ICollection<CsSecondment> CsSecondments { get; set; } = new List<CsSecondment>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<FacultyAllowanceDeduction> FacultyAllowanceDeductions { get; set; } = new List<FacultyAllowanceDeduction>();

    public virtual ICollection<FacultyAppointment> FacultyAppointments { get; set; } = new List<FacultyAppointment>();

    public virtual ICollection<FacultyCurrentSalaryLevel> FacultyCurrentSalaryLevels { get; set; } = new List<FacultyCurrentSalaryLevel>();

    public virtual ICollection<FacultyLeaveApplication> FacultyLeaveApplications { get; set; } = new List<FacultyLeaveApplication>();

    public virtual ICollection<PayrollLine> PayrollLines { get; set; } = new List<PayrollLine>();

    public virtual ICollection<PersonPayAssignment> PersonPayAssignments { get; set; } = new List<PersonPayAssignment>();

    public virtual ICollection<RequestApproval> RequestApprovals { get; set; } = new List<RequestApproval>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
