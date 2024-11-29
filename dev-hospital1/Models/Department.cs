using System;
using System.Collections.Generic;

namespace dev_hospital1.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
