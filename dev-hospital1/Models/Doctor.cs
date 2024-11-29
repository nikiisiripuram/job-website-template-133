using System;
using System.Collections.Generic;

namespace dev_hospital1.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string DoctorName { get; set; } = null!;

    public string Qualification { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
